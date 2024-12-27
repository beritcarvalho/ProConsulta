using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProConsulta.Data.Configuracoes;
using ProConsulta.Data.Seeds;
using ProConsulta.Models;
using System.Reflection;

namespace ProConsulta.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }        
        public DbSet<Agendamento> Agendamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            AplicarCofiguracoesBase(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            new DbInitializer(builder).Seed();
            base.OnModelCreating(builder);
        }

        private void AplicarCofiguracoesBase(ModelBuilder builder)
        {
            var tiposEntidades = builder.Model.GetEntityTypes()
                .Where(t => t.ClrType.BaseType != null &&
                            t.ClrType.BaseType.IsGenericType &&
                            t.ClrType.BaseType.GetGenericTypeDefinition() == typeof(ModelBase<>))
                .Select(t => t.ClrType);


            foreach (var tipoEntidade in tiposEntidades)
            {                
                var keyType = tipoEntidade.BaseType.GetGenericArguments()[0];
                
                var configType = typeof(BaseConfiguracao<,>).MakeGenericType(tipoEntidade, keyType);
                var configurationInstance = Activator.CreateInstance(configType);
                
                builder.ApplyConfiguration((dynamic)configurationInstance);
            }
        }
    }
}
