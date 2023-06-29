using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;

namespace Biblioteca.Models
{
    public class BibliotecaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=db;DataBase=Biblioteca;Uid=root;Password=1234",
                new MySqlServerVersion(new Version(8, 0, 0)), 
                mySqlOptions => {
                    mySqlOptions.EnableRetryOnFailure();
                });

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
    }
}
