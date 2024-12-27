namespace ProConsulta.Models
{
    public class Agendamento : ModelBase<int>
    {
        public string Observacao { get; set; }
        
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }
        
        public TimeSpan HoraConsulta{ get; set; }
        public TimeSpan DataConsulta { get; set; }

        
        
    }
}
