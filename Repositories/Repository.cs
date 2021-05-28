using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    public class Context : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }
        public DbSet<VeiculoLocacao> VeiculoLocacao { get; set; }
        
         protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql("Server=localhost;User Id=root;Database=locadoradb2");
        }
    }
}



