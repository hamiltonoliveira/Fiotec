using Domain.Entities;

namespace Application.Interfaces
{
    public interface ISolicitante
    {
        Task<Solicitante> GetSolicitanteAsync(string cpf, string nome);
        Task<Solicitante> InsertAsync(Solicitante entity);
    }
}
