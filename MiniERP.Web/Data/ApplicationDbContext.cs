using Microsoft.EntityFrameworkCore;
using MiniERP.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MiniERP.Web.Data
{
    /// <summary>
    /// Contexto da base de dados da aplicação
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext
    {
        /// <summary>
        /// Construtor do contexto
        /// </summary>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Empregado> Empregados { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Fatura> Faturas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
