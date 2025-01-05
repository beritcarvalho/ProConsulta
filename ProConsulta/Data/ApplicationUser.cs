using Microsoft.AspNetCore.Identity;

namespace ProConsulta.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            DataCriacao = DateTime.Now;
        }

        public DateTime DataCriacao { get; set; }
        public bool Excluido { get; set; }
        public DateTime? DataExclusao { get; set; }
    }
}
