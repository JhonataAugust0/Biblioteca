using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models
{
    public class EmprestimoService 
    {
        public void Inserir(Emprestimo e)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Emprestimos.Add(e);
                bc.SaveChanges();
            }
        }

        public void Atualizar(Emprestimo e)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                Emprestimo emprestimo = bc.Emprestimos.Find(e.Id);
                emprestimo.NomeUsuario = e.NomeUsuario;
                emprestimo.Telefone = e.Telefone;
                emprestimo.LivroId = e.LivroId;
                emprestimo.DataEmprestimo = e.DataEmprestimo;
                emprestimo.DataDevolucao = e.DataDevolucao;

                bc.SaveChanges();
            }
        }

        public ICollection<Emprestimo> ListarTodos(FiltrosEmprestimos filtro)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                IQueryable<Emprestimo> query = bc.Emprestimos.Include(e => e.Livro);

                if (filtro != null)
                {
                    if (filtro.TipoFiltro == "Usuario")
                    {
                        query = query.Where(e => e.NomeUsuario.Contains(filtro.Filtro));
                    }
                    else if (filtro.TipoFiltro == "Livro")
                    {
                        query = query.Where(e => e.Livro.Titulo.Contains(filtro.Filtro) || e.Livro.Autor.Contains(filtro.Filtro));
                    }
                }

                return query.ToList();
            }
        }


        public Emprestimo ObterPorId(int id)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Emprestimos.Find(id);
            }
        }
    }
}