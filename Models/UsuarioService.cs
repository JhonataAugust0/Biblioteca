using Biblioteca.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

namespace Biblioteca.Controllers
{

  public class UsuarioService
  {
    public void Inserir(Usuario u)
    {
      using (BibliotecaContext bc = new BibliotecaContext())
      {
        u.Senha = CalculateMD5Hash(u.Senha);

        bc.Usuarios.Add(u);
        bc.SaveChanges();
      }
    }

    public string CalculateMD5Hash(string input)
    {
        using (var md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
              sb.Append(hashBytes[i].ToString("x2"));
            }

            return sb.ToString();
        }
    }
    public void Atualizar(Usuario u)
    {
      using (BibliotecaContext bc = new BibliotecaContext())
      {
        Usuario usuario = bc.Usuarios.Find(u.Id);
        usuario.Nome = u.Nome;
        usuario.Senha = u.Senha;

        bc.SaveChanges();
      }
    }

    public ICollection<Usuario> ListarTodos()
    {
        using (BibliotecaContext bc = new BibliotecaContext())
        {
            IQueryable<Usuario> query;
            Console.WriteLine("Listagem de Usuários");
            query = bc.Usuarios;
            Console.WriteLine(query.OrderBy(l => l.Nome).ToList());
            return query.OrderBy(l => l.Nome).ToList();
        }
    }

    public Usuario ObterPorId(int id)
    {
      using (BibliotecaContext bc = new BibliotecaContext())
      {
        return bc.Usuarios.Find(id);
      }
    }

    public static Usuario ObterUsuarioPorLogin(string login)
    {
        using (BibliotecaContext bc = new BibliotecaContext())
        {
            return bc.Usuarios.FirstOrDefault(u => u.Nome == login);
        }
    }
    public void Deletar(int id)
    {
        using (BibliotecaContext bc = new BibliotecaContext())
        {
            Usuario usuario = bc.Usuarios.Find(id);
            if (usuario != null)
            {
                bc.Usuarios.Remove(usuario);
                bc.SaveChanges();
            }
        }
    }
  }

}
