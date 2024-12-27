using ProConsulta.Data;

namespace ProConsulta.Models
{
    public class Atendente : ApplicationUser
    {
        public string Nome { get; set; } = null!;
        public DateTime DataCriacao { get; set; }
        public bool Excluido { get; set; }
        public DateTime? DataExclusao { get; set; }
    }
}
