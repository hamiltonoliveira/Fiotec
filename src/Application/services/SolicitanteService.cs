using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;

namespace Application.services
{
    public class SolicitanteService : ISolicitanteService
    {
        private readonly ISolicitante _solicitanteRepository;

        public SolicitanteService(ISolicitante solicitanteRepository)
        {
            _solicitanteRepository = solicitanteRepository;
        }

        public async Task<Solicitante> GetSolicitanteAsync(int Id)
        {
            var solicitante = await _solicitanteRepository.GetSolicitanteAsync(Id);

            if (solicitante == null)
            {
                throw new KeyNotFoundException("Solicitante não encontrado.");
            }
            return solicitante;
        }

        public async Task<Solicitante> InsertAsync(Solicitante entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "O objeto solicitante não pode ser nulo.");
            }

            if (string.IsNullOrEmpty(entity.CPF) || string.IsNullOrEmpty(entity.Nome))
            {
                throw new ArgumentException("CPF e Nome são obrigatórios.");
            }

            return await _solicitanteRepository.InsertAsync(entity);
        }
    }
} 