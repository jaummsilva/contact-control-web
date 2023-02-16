using ContatosMVC.Data.Map;
using ContatosMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ContatosMVC.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext()
        {

        }
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContatoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
