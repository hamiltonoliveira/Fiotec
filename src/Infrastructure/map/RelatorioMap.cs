using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Map
{
    public class RelatorioMap : IEntityTypeConfiguration<Relatorio>
    {
        public void Configure(EntityTypeBuilder<Relatorio> builder)
        {
            builder.ToTable("Relatorios");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(r => r.DataSolicitacao).HasColumnType("datetime")
                .IsRequired();

            builder.Property(r => r.Arbovirose)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(r => r.SemanaInicio)
                .IsRequired();

            builder.Property(r => r.SemanaTermino)
                .IsRequired();

            builder.Property(r => r.CodigoIBGE)
                .HasMaxLength(10)
                .IsRequired();

            builder.HasOne(r => r.Solicitante)
                .WithMany(s => s.Relatorios)
                .HasForeignKey(r => r.SolicitanteId);
        }
    }
}
