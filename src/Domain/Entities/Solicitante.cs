namespace Domain.Entities
{
    public class Solicitante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public ICollection<Relatorio> Relatorios { get; set; }
    }
}
