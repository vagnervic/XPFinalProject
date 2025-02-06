using Microsoft.EntityFrameworkCore;
using XPFinalProject.Models;

namespace XPFinalProject.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
            
        }

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<PedidoModel> Pedidos { get; set; }

    }
}
