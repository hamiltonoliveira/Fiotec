using Domain.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure
{
    public class RelatorioRepository : IRelatorio
    {
        public Task<Relatorio> InsertRelatorioAsync(Relatorio relatorio)
        {
            throw new NotImplementedException();
        }
    }
}
