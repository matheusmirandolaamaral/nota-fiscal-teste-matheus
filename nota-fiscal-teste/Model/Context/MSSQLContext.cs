using Microsoft.EntityFrameworkCore;

namespace nota_fiscal_teste.Model.Context
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext(DbContextOptions<MSSQLContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

    }
}
