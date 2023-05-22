using FluxoCaixa.Core.DomainObjects;

namespace FluxoCaixa.Lancamentos.Domain
{
    public class Lancamento : Entity, IAggregateRoot
    {
        public double Valor { get; private set; }
        public DateTime DataRecebimento { get; set; }
        public TipoLancamento TipoLancamento { get; private set; }

        // EF Constutor
        protected Lancamento()
        {
        }

        public Lancamento(double valor, TipoLancamento tipoLancamento, DateTime dataRecebimento)
        {
            Valor = valor;
            TipoLancamento = tipoLancamento;
            DataRecebimento = dataRecebimento;
            Validar();
        }

        public void Validar()
        {
            Validacoes.ValidarMinimoMaximo(Valor, double.MinValue, double.MaxValue, "O campo Valor do lançamento é inválido");
            Validacoes.ValidarSeNulo(TipoLancamento, "O campo TipoLancamento não pode estar vazio");
            Validacoes.ValidarSeNulo(DataRecebimento, "O campo DataRecebimento não pode estar vazio");
        }
    }
}
