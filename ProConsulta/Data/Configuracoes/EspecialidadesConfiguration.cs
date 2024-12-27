using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsulta.Models;

namespace ProConsulta.Data.Configuracoes
{
    public class EspecialidadesConfiguration : IEntityTypeConfiguration<Especialidade>
    {
        public void Configure(EntityTypeBuilder<Especialidade> builder)
        {
            builder.ToTable("Especialidades");

            builder.HasKey(especialidade => especialidade.Id);

            builder.Property(especialidade => especialidade.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR(60)");

            builder.Property(especialidade => especialidade.Descricao)    
                .HasColumnType("VARCHAR(150)");

            builder.HasMany(especialidade => especialidade.Medicos)
                .WithOne(medico => medico.Especialidade)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
