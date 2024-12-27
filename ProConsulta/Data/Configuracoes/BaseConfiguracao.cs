using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsulta.Models;

namespace ProConsulta.Data.Configuracoes
{
    public class BaseConfiguracao<T, TKey> : IEntityTypeConfiguration<T> where T : ModelBase<TKey>
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(model => model.DataCriacao)
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            builder.Property(model => model.Excluido)
                .HasDefaultValue(false)
                .IsRequired();
        }
    }
}
