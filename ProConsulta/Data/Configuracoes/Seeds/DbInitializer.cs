using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProConsulta.Models;

namespace ProConsulta.Data.Configuracoes.Seeds
{
    public class DbInitializer
    {
        private readonly ModelBuilder _builder;

        public DbInitializer(ModelBuilder builder)
        {
            _builder = builder;
        }

        internal void Seed()
        {
            _builder.Entity<IdentityRole>().HasData
                (
                    new IdentityRole
                    {
                        Id = "ca61e48c-d53c-4102-a3a3-db5e25c593c0",
                        Name = "Atendente",
                        NormalizedName = "ATENDENTE"
                    },
                    new IdentityRole
                    {
                        Id = "2d3bebf6-752b-40c3-af02-82f7add0bd58",
                        Name = "Medico",
                        NormalizedName = "MEDICO"
                    }
                );

            var hasher = new PasswordHasher<IdentityUser>();

            _builder.Entity<Atendente>().HasData
                (
                    new Atendente
                    {
                        Id = "699cc9c0-7e07-4967-89ef-bb2791033361",
                        Nome = "Cilio Albert",
                        Email = "cilio@cilio.com",
                        EmailConfirmed = true,
                        UserName = "cilio@cilio.com",
                        NormalizedEmail = "CILIO@CILIO.COM",
                        NormalizedUserName = "CILIO@CILIO.COM",
                        PasswordHash = hasher.HashPassword(null, "senha"),
                        DataCriacao = DateTime.Now,
                    }
                );

            _builder.Entity<IdentityUserRole<string>>().HasData                              
                (
                    new IdentityUserRole<string>
                    {
                        RoleId = "ca61e48c-d53c-4102-a3a3-db5e25c593c0",
                        UserId = "699cc9c0-7e07-4967-89ef-bb2791033361"
                    }                
                );

            _builder.Entity<Especialidade>().HasData
                (
                    new Especialidade { Id = 1, Nome = "Cardiologia" },
                    new Especialidade { Id = 2, Nome = "Dermatologia" },
                    new Especialidade { Id = 3, Nome = "Gastroenterologia" },
                    new Especialidade { Id = 4, Nome = "Neurologia" },
                    new Especialidade { Id = 5, Nome = "Ortopedia" },
                    new Especialidade { Id = 6, Nome = "Pediatria" },
                    new Especialidade { Id = 7, Nome = "Psiquiatria" }
                );
        }
    }
}
