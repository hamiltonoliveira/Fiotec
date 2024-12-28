using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Solicitante> Solicitantes { get; set; }
        public DbSet<Relatorio> Relatorios { get; set; }
    }
}
