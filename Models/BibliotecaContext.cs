using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;

namespace Biblioteca.Models
{
    public class BibliotecaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user=root;password=1234;database=Biblioteca",
                new MySqlServerVersion(new Version(8))); 

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
    }
}
