using System.ComponentModel.DataAnnotations;

namespace ProConsulta.Components.Pages.Pacientes
{
    public class PacienteInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(50, ErrorMessage = "O nome de conter no máximo 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O documento é obrigatório")]
        public string Documento { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "O email é inválido")]
        [MaxLength(50, ErrorMessage = "O email de conter no máximo 50 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        public DateTime? DataNascimento { get; set; }
    }
}
