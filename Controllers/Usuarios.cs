using System;
using System.Collections.Generic;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class Usuarios : Controller{
        public IActionResult Cadastro()
        {
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

        public IActionResult Listagem()
        {
            Autenticacao.CheckLogin(this);
            UsuarioService usuarioService = new UsuarioService();
            ICollection<Usuario> usuarios = usuarioService.ListarTodos();
            Console.WriteLine(usuarios);
            return View(usuarios);
        }

        public IActionResult Edicao(int id)
        {
            Autenticacao.CheckLogin(this);
            UsuarioService ls = new UsuarioService();
            Usuario l = ls.ObterPorId(id);
            return View(l);
        }

        public IActionResult Deletar(int id)
        {
            Autenticacao.CheckLogin(this);
            UsuarioService ls = new UsuarioService();
            ls.Deletar(id);
            return RedirectToAction("Index");
        }
    }
}
// public class Usuarios : Controller
//     {
//         public IActionResult Cadastro()
//         {
//             Autenticacao.CheckLogin(this);
//             return View();
//         }

//         [HttpPost]
//         public IActionResult Cadastro(Usuario l)
//         {
//             UsuarioService UsuarioService = new UsuarioService();

//             if(l.Id == 0)
//             {
//                 UsuarioService.Inserir(l);
//             }
//             else
//             {
//                 UsuarioService.Atualizar(l);
//             }

//             return RedirectToAction("ListagemUsuario");
//         }

//         public IActionResult Listagem()
//         {
//             Console.WriteLine("Listagem de Usuários");
//             Autenticacao.CheckLogin(this);
//             UsuarioService usuarioService = new UsuarioService();
//             ICollection<Usuario> usuarios = usuarioService.ListarTodos();
//             Console.WriteLine(usuarios);
//             return View(usuarios);
//         }

//         public IActionResult Edicao(int id)
//         {
//             Autenticacao.CheckLogin(this);
//             UsuarioService ls = new UsuarioService();
//             Usuario l = ls.ObterPorId(id);
//             return View(l);
//         }

//         public IActionResult Deletar(int id)
//         {
//             Autenticacao.CheckLogin(this);
//             UsuarioService ls = new UsuarioService();
//             ls.Deletar(id);
//             return RedirectToAction("Index");
//         }
//     }
// }
