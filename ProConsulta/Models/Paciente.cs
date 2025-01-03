using System.Globalization;

namespace ProConsulta.Models
{
    public class Paciente : ModelBase<int>
    {
        public Paciente()
        {
            DataCriacao = DateTime.Now;
        }

        public string Nome { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public DateTime DataNascimento { get; set; }

        public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
    }
}
