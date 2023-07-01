using System;
using System.Collections.Generic;
using System.Linq;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class LivroController : Controller
    {
        public IActionResult Cadastro()
        {
            Autenticacao.CheckLogin(this);
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Livro l)
        {
            Autenticacao.CheckLogin(this);
            LivroService livroService = new LivroService();

            if(l.Id == 0)
            {
                livroService.Inserir(l);
            }
            else
            {
                livroService.Atualizar(l);
            }

            return RedirectToAction("Listagem");
        }

        public IActionResult Listagem(string tipoFiltro, string filtro, int pagina = 1, int itensPorPagina = 10)
        {
            Autenticacao.CheckLogin(this);
            FiltrosLivros objFiltro = null;
            if (!string.IsNullOrEmpty(filtro))
            {
                objFiltro = new FiltrosLivros();
                objFiltro.Filtro = filtro;
                objFiltro.TipoFiltro = tipoFiltro;
            }
            LivroService livroService = new LivroService();

            ICollection<Livro> livros = livroService.ListarTodos(objFiltro);

            int totalItens = livros.Count;
            int totalPaginas = (int)Math.Ceiling((double)totalItens / itensPorPagina);

            pagina = Math.Max(1, Math.Min(pagina, totalPaginas));

            List<Livro> livrosPaginados = livros
                .Skip((pagina - 1) * itensPorPagina)
                .Take(itensPorPagina)
                .ToList();

            PaginacaoViewModel<Livro> modeloPaginacao = new PaginacaoViewModel<Livro>
            {
                Itens = livrosPaginados,
                PaginaAtual = pagina,
                TotalPaginas = totalPaginas,
                ItensPorPagina = itensPorPagina
            };

            return View(modeloPaginacao);
        }


        public IActionResult Edicao(int id)
        {
            Autenticacao.CheckLogin(this);
            LivroService ls = new LivroService();
            Livro l = ls.ObterPorId(id);
            return View(l);
        }
    }
}
