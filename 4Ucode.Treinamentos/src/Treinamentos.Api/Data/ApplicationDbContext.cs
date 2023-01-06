using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Treinamentos.Api.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql("server=mysql-banco-api.mysql.database.azure.com;initial catalog=TreinamentosDB;uid=MysqlRoot;pwd=Mudar#123",
            Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.0-mysql")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
    }
}