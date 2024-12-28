using Domain.Entities;

namespace Application.Interfaces
{
    public interface IRelatorioService
    {
        Task<Relatorio> InsertRelatorioAsync(Relatorio relatorio);
    }
}
