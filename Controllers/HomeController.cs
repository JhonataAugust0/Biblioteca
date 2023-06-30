using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Biblioteca.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;

namespace Biblioteca.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Autenticacao.CheckLogin(this);
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string login, string senha)
        {   
            Console.WriteLine("Login: " + login);
            Console.WriteLine("Senha: " + senha);
            if(login != "admin" || senha != "123")
            {
                ViewData["Erro"] = "Senha inválida";
                return View();
            }
            else
            {
                HttpContext.Session.SetString("user", "admin");
                return RedirectToAction("Index");
            }
        }  

        private string CalculateMD5Hash(string input)
        {
            // Cria uma instância do objeto MD5
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                // Converte a string de entrada para um array de bytes
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

                // Calcula o hash MD5 para o array de bytes
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Converte o array de bytes para uma string hexadecimal
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                // Retorna a string hexadecimal resultante
                Console.WriteLine(sb.ToString());
                return sb.ToString();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
