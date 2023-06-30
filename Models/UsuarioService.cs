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
            return bc.Usuarios.ToList();
        }
    }

    public Usuario ObterPorId(int id)
    {
      using (BibliotecaContext bc = new BibliotecaContext())
      {
        return bc.Usuarios.Find(id);
      }
    }
  }

}