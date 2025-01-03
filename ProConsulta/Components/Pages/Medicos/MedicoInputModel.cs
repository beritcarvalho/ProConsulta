using ProConsulta.Models;
using System.ComponentModel.DataAnnotations;

namespace ProConsulta.Components.Pages.Medicos
{
    public class MedicoInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} deve ser fornecido")]
        [MaxLength(50, ErrorMessage = "{0} deve conter no máximo {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} deve ser fornecido")]
        public string Documento { get; set; }


        [Required(ErrorMessage = "{0} deve ser fornecido")]        
        public string Crm { get; set; }

        [Required(ErrorMessage = "{0} deve ser fornecido")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "{0} deve ser fornecido")]
        [RegularExpression("[1-9][0-9]*", ErrorMessage = "Valor selecionado é inválido")]
        public int EspecialidadeId { get; set; }        
    }
}
