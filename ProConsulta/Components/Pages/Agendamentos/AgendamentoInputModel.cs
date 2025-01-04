using ProConsulta.Models;
using System.ComponentModel.DataAnnotations;

namespace ProConsulta.Components.Pages.Agendamentos
{
    public class AgendamentoInputModel
    {
        [MaxLength(250, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres)")]
        public string Observacao { get; set; }

        
        [Required(ErrorMessage = "{0} deve ser fornecido")]
        public Paciente Paciente { get; set; }

        [Required(ErrorMessage = "{0} deve ser fornecido")]
        public Medico Medico { get; set; }

        [Required(ErrorMessage = "{0} deve ser fornecido")]
        public TimeSpan? HoraConsulta { get; set; }

        [Required(ErrorMessage = "{0} deve ser fornecido")]
        public DateTime? DataConsulta { get; set; }
    }
}
