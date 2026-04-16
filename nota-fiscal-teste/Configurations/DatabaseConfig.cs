using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using nota_fiscal_teste.Model.Context;

namespace nota_fiscal_teste.Configurations
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["MSSQLServerConnection:MSSQLServerConnectionString"];

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Connection string 'MSSQLServerConnectionString' is not found");
            }
            services.AddDbContext<MSSQLContext>(options => options.UseSqlServer(connectionString));
            return services;
        }
    }
}
