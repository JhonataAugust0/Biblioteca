using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Cadastro()
        {
            Autenticacao.CheckLogin(this);
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario l)
        {
            UsuarioService UsuarioService = new UsuarioService();

            if(l.Id == 0)
            {
                UsuarioService.Inserir(l);
            }
            else
            {
                UsuarioService.Atualizar(l);
            }

            return RedirectToAction("Listagem");
        }

        // public IActionResult Listagem(string tipoFiltro, string filtro)
        // {
        //     Autenticacao.CheckLogin(this);
        //     UsuarioService UsuarioService = new UsuarioService();
        //     return View(UsuarioService.ListarTodos());
        // }

        public IActionResult Edicao(int id)
        {
            Autenticacao.CheckLogin(this);
            UsuarioService ls = new UsuarioService();
            Usuario l = ls.ObterPorId(id);
            return View(l);
        }
    }
}