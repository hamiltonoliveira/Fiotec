using Domain.Entities;
using Infrastructure.data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class SolicitanteRepository : ISolicitante 
    {
        private readonly DataContext _context;

        public SolicitanteRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Solicitante> GetSolicitanteAsync(int id)
        {
            try
            {
                return await _context.Solicitante.FirstOrDefaultAsync(s => s.Id == id);
            }
            catch (Exception ex)
            {
                // Log do erro
                throw new Exception("Erro ao consultar solicitante: " + ex.Message, ex);
            }
        }

        public async Task<Solicitante> InsertAsync(Solicitante entity)
        {
            await _context.Solicitante.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
