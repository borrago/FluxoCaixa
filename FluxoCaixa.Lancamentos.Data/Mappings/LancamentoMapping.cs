using FluxoCaixa.Lancamentos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluxoCaixa.Lancamentos.Data.Mappings
{
    public class LancamentoMapping : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Valor)
                .IsRequired();

            builder.Property(c => c.TipoLancamento)
                .IsRequired();

            builder.Property(c => c.DataRecebimento)
                .IsRequired();
        }
    }
}
