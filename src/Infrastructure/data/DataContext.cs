using Domain.Entities;
using Infrastructure.Map;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DataContext()
        {
        }
        public DbSet<Solicitante> Solicitante { get; set; }
        public DbSet<Relatorio> Relatorio { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SolicitanteMap());
            modelBuilder.ApplyConfiguration(new RelatorioMap());
        }
   }
}
