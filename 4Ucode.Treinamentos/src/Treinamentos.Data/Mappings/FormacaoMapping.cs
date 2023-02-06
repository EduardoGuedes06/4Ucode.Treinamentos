using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Treinamentos.Domain.Model;

namespace Treinamentos.Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Formacao>
    {
        public void Configure(EntityTypeBuilder<Formacao> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(35)");

            builder.Property(p => p.Bios)
                .IsRequired()
                .HasColumnType("varchar(100)");


            builder.Property(p => p.Foto)
                .IsRequired()
                .HasColumnType("varchar(100)");

            // 1 : N => Formacao : Categorias
            builder.HasMany(f => f.Categorias)
                .WithOne(p => p.Formacao)
                .HasForeignKey(p => p.FormacaoId);


            builder.ToTable("Formacoes");
        }
    }
}
