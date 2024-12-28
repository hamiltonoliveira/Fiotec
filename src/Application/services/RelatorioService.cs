
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;

namespace Application.services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IRelatorioRepository _relatorioRepository;

        public RelatorioService(IRelatorioRepository relatorioRepository)
        {
            _relatorioRepository = relatorioRepository;
        }
        public async Task<Relatorio> InsertRelatorioAsync(Relatorio relatorio)
        {
            if (relatorio == null)
            {
                throw new ArgumentNullException(nameof(relatorio), "O objeto Relatório não pode ser nulo.");
            }

            if (string.IsNullOrEmpty(relatorio.Arbovirose))
            {
                throw new ArgumentException("O campo 'Arbovirose' é obrigatório.");
            }

            if (relatorio.SemanaInicio <= 0 || relatorio.SemanaTermino <= 0)
            {
                throw new ArgumentException("As semanas de início e término devem ser valores positivos.");
            }

            if (relatorio.SemanaInicio > relatorio.SemanaTermino)
            {
                throw new ArgumentException("A semana de início não pode ser maior que a semana de término.");
            }

            if (string.IsNullOrEmpty(relatorio.CodigoIBGE))
            {
                throw new ArgumentException("O campo 'Código IBGE' é obrigatório.");
            }

            return await _relatorioRepository.InsertRelatorioAsync(relatorio);
        }
    }

}
