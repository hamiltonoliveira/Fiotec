using Domain.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure
{
    public class SolicitanteRepository : ISolicitante 
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
