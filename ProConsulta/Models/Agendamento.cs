using System.ComponentModel.DataAnnotations;

namespace ProConsulta.Models
{
    public class Agendamento : ModelBase<int>
    {
        public Agendamento()
        {
            DataCriacao = DateTime.Now;
        }
        
        public string? Observacao { get; set; }
        
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }
        
        public TimeSpan HoraConsulta{ get; set; }
        public DateTime DataConsulta { get; set; }
    }
}
