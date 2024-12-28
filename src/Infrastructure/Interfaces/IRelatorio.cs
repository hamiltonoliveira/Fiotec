using Domain.Entities;

namespace Infrastructure.Interfaces
{
    public interface IRelatorio
    {
        Task<Relatorio> InsertRelatorioAsync(Relatorio relatorio);
    }
}
