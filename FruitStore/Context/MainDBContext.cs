using Microsoft.EntityFrameworkCore;

namespace FruitStore.Context
{
    public class MainDBContext : DbContext
    {
        public MainDBContext(DbContextOptions<MainDBContext> options) : base(options)
        {
        }
        public DbSet<Models.Fruit> Fruits { get; set; }
        //public DbSet<Models.Order> Orders { get; set; }
    }
}
