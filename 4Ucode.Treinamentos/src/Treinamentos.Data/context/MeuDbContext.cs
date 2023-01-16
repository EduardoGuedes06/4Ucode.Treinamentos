
using Microsoft.EntityFrameworkCore;
using Treinamentos.Domain.Model;

namespace Data.context
{
    public class MeuDbContext : DbContext
        {
            public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options) { }


            public DbSet<Aluno> Alunos { get; set; }
            public DbSet<Documento> Documentos { get; set; }
            
        //..................................................

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                foreach (var property in modelBuilder.Model.GetEntityTypes()
                    .SelectMany(e => e.GetProperties()
                        .Where(p => p.ClrType == typeof(string))))
                    property.SetColumnType("varchar(100)");

                modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

                foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

                base.OnModelCreating(modelBuilder);
            }

            public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
            {
                foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                    }

                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property("DataCadastro").IsModified = false;
                    }
                }

                return base.SaveChangesAsync(cancellationToken);
            }

        }
    }

