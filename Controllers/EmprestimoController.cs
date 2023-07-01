using Biblioteca.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Controllers
{

    public class EmprestimoController : Controller
    {
        public IActionResult Cadastro()
        {
            Autenticacao.CheckLogin(this);
            LivroService livroService = new LivroService();
            EmprestimoService emprestimoService = new EmprestimoService();

            CadEmprestimoViewModel cadModel = new CadEmprestimoViewModel();
            cadModel.Livros = livroService.ListarTodos();
            return View(cadModel);
        }

        [HttpPost]
        public IActionResult Cadastro(CadEmprestimoViewModel viewModel)
        {
            Autenticacao.CheckLogin(this);

            EmprestimoService emprestimoService = new EmprestimoService();

            if(viewModel.Emprestimo.Id == 0)
            {
                emprestimoService.Inserir(viewModel.Emprestimo);
            }
            else
            {
                emprestimoService.Atualizar(viewModel.Emprestimo);
            }
            return RedirectToAction("Listagem");
        }

        public IActionResult Listagem(string tipoFiltro, string filtro, int pagina = 1, int itensPorPagina = 10)
        {
            Autenticacao.CheckLogin(this);
            FiltrosEmprestimos objFiltro = null;
            if (!string.IsNullOrEmpty(filtro))
            {
                objFiltro = new FiltrosEmprestimos();
                objFiltro.Filtro = filtro;
                objFiltro.TipoFiltro = tipoFiltro;
            }
            EmprestimoService emprestimoService = new EmprestimoService();

            ICollection<Emprestimo> emprestimos = emprestimoService.ListarTodos(objFiltro);

            int totalItens = emprestimos.Count;
            int totalPaginas = (int)Math.Ceiling((double)totalItens / itensPorPagina);

            pagina = Math.Max(1, Math.Min(pagina, totalPaginas));

            List<Emprestimo> emprestimosPaginados = emprestimos
                .Skip((pagina - 1) * itensPorPagina)
                .Take(itensPorPagina)
                .ToList();

            PaginacaoViewModel<Emprestimo> modeloPaginacao = new PaginacaoViewModel<Emprestimo>
            {
                Itens = emprestimosPaginados,
                PaginaAtual = pagina,
                TotalPaginas = totalPaginas,
                ItensPorPagina = itensPorPagina
            };

            return View(modeloPaginacao);
        }


        public IActionResult Edicao(int id)
        {
            Autenticacao.CheckLogin(this);
            LivroService livroService = new LivroService();
            EmprestimoService em = new EmprestimoService();
            Emprestimo e = em.ObterPorId(id);

            CadEmprestimoViewModel cadModel = new CadEmprestimoViewModel();
            cadModel.Livros = livroService.ListarTodos();
            cadModel.Emprestimo = e;

            return View(cadModel);
        }
    }
}
