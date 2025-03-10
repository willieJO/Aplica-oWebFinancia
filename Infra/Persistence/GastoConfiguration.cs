using APIFinancia.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIFinancia.Infra.Persistence
{
    public class GastoConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.ToTable("Gastos");

            builder.HasKey(x => x.Id); 

            builder.Property(x => x.Valor)
                .IsRequired()
                .HasColumnType("decimal(18,2)"); 

            builder.Property(x => x.TipoGasto)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(x => x.Usuario)
                .WithMany() 
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
