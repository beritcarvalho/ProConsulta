namespace ProConsulta.Models
{
    public class Especialidade : ModelBase<int>
    {
        public string Nome { get; set; } = null!;
        public string? Descricao { get; set; }

        public ICollection<Medico> Medicos { get; set; } = new List<Medico>();
    }
}
