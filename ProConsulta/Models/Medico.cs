namespace ProConsulta.Models
{
    public class Medico : ModelBase<int>
    {
        public Medico() 
        {
            DataCriacao = DateTime.Now;
        }

        public string Nome { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public string Crm { get; set; }
        public string Telefone { get; set; } = null!;
        public int EspecialidadeId { get; set; }
        public Especialidade Especialidade { get; set; } = null!;

        public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
    }
}
