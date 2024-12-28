using Domain.Entities;

namespace Infrastructure.Interfaces
{
    public interface IRelatorioRepository
    {
        Task<Relatorio> InsertRelatorioAsync(Relatorio relatorio);
    }
}
