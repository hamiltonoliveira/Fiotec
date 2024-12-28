using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Relatorio
    {
        public int Id { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public string Arbovirose { get; set; }
        public int SemanaInicio { get; set; }
        public int SemanaTermino { get; set; }
        public string CodigoIBGE { get; set; }
        public int SolicitanteId { get; set; }

        [ForeignKey(nameof(SolicitanteId))]
        public Solicitante Solicitante { get; set; }
    }
}
