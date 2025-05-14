using Microsoft.EntityFrameworkCore;

namespace ListaDeCompras.Models
{
    public class ListaDeComprasDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public ListaDeComprasDbContext(DbContextOptions<ListaDeComprasDbContext> options) : base(options)
        {

        }
    }
}
