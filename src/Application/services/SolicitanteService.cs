using Application.Interfaces;
using Domain.Entities;

namespace Application.services
{
    public class SolicitanteService : ISolicitante
    {
        public Task<Solicitante> GetSolicitanteAsync(string cpf, string nome)
        {
            throw new NotImplementedException();
        }

        public Task<Solicitante> InsertAsync(Solicitante entity)
        {
            throw new NotImplementedException();
        }
    }
}
