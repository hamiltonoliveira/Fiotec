using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Map
{
    public class SolicitanteMap : IEntityTypeConfiguration<Solicitante>
    {
        public void Configure(EntityTypeBuilder<Solicitante> builder)
        {
            builder.ToTable("Solicitantes");
           
            builder.HasKey(s => s.Id);
             
            builder.Property(s => s.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(s => s.Nome)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(s => s.CPF)
                .HasMaxLength(15)  
                .IsRequired();

            builder.HasMany(s => s.Relatorios)
                .WithOne(r => r.Solicitante)
                .HasForeignKey(r => r.SolicitanteId);
        }
    }
}
