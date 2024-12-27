using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsulta.Models;

namespace ProConsulta.Data.Configuracoes
{
    public class PacienteConfiguracao : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("Pacientes");

            builder.HasKey(paciente => paciente.Id);

            builder.Property(paciente => paciente.Nome)
                .IsRequired()
                .HasColumnType("NVARCHAR(50)");

            builder.Property(paciente => paciente.Documento)
                .IsRequired()
                .HasColumnType("NVARCHAR(11)");

            builder.Property(paciente => paciente.Email)
                .IsRequired()
                .HasColumnType("NVARCHAR(50)");

            builder.Property(paciente => paciente.Telefone)
                .IsRequired()
                .HasColumnType("NVARCHAR(11)");

            builder.HasIndex(paciente => paciente.Documento)
                .IsUnique();

            builder.HasMany(paciente => paciente.Agendamentos)
                .WithOne(agendamento => agendamento.Paciente)
                .HasForeignKey(agendamento => agendamento.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
