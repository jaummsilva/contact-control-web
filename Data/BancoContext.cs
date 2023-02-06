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
    }
}
