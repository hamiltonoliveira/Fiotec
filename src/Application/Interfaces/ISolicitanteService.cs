using Domain.Entities;

namespace Application.Interfaces
{
    public interface ISolicitanteService
    {
        Task<Solicitante> GetSolicitanteAsync(int Id);
        Task<Solicitante> InsertAsync(Solicitante entity);
    }
}
