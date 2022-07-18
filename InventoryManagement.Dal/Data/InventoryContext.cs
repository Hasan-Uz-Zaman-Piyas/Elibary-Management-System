using InventoryManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Data
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions options): base(options)
        {

        }
        public virtual DbSet<Unit> Units { get; set; }
    }
}
