using Domain.Entities;
using Infrastructure.data;
using Infrastructure.Interfaces;

namespace Infrastructure
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly DataContext _context;

        public RelatorioRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Relatorio> InsertRelatorioAsync(Relatorio relatorio)
        {
            await _context.Relatorio.AddAsync(relatorio);
            await _context.SaveChangesAsync();
            return relatorio;
        }
    }
}
