using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsulta.Models;

namespace ProConsulta.Data.Configuracoes
{
    public class MedicoConfiguracao : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable("Medicos");

            builder.HasKey(medico => medico.Id);

            builder.Property(medico => medico.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR(50)");

            builder.Property(medico => medico.Documento)
                .IsRequired()
                .HasColumnType("NVARCHAR(11)");

            builder.Property(medico => medico.Crm)
                .IsRequired()
                .HasColumnType("NVARCHAR(8)");

            builder.Property(medico => medico.Telefone)
                .IsRequired()
                .HasColumnType("NVARCHAR(11)");

            builder.Property(medico => medico.EspecialidadeId)
                .IsRequired();

            builder.HasIndex(medico => medico.Documento)
                .IsUnique();

            builder.HasMany(medico => medico.Agendamentos)
                .WithOne(agendamento => agendamento.Medico)
                .HasForeignKey(agendamento => agendamento.MedicoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
