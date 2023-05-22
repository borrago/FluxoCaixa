using FluxoCaixa.Core.DomainObjects;
using System.Drawing;

namespace FluxoCaixa.Lancamentos.Domain.Tests
{
    public class LancamentoTests
    {
        [Fact]
        public void Cargo_Validar_ValidacoesDevemRetornarExceptions()
        {
            // Arrange & Act & Assert

            var ex = Assert.Throws<DomainException>(() => new Lancamento(double.MinValue - 1, TipoLancamento.Debito, DateTime.Now.Date));
            Assert.Equal("O campo Valor do lançamento é inválido", ex.Message);

            ex = Assert.Throws<DomainException>(() => new Lancamento(double.MaxValue + 1, TipoLancamento.Debito, DateTime.Now.Date));
            Assert.Equal("O campo Valor do lançamento é inválido", ex.Message);
        }
    }
}