using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsulta.Models;

namespace ProConsulta.Data.Configuracoes
{
    public class AgendamentoConfiguracao : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.ToTable("Agendamentos");

            builder.HasKey(agendamento => agendamento.Id);

            builder.Property(agendamento => agendamento.Observacao)                
                .HasColumnType("VARCHAR(250)");

            builder.Property(agendamento => agendamento.PacienteId)
                .IsRequired();

            builder.Property(agendamento => agendamento.MedicoId)
                .IsRequired();
        }
    }
}
