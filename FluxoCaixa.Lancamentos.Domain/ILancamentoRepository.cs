using FluxoCaixa.Core.Data;
using FluxoCaixa.Core.DomainObjects;
using System.Linq.Expressions;

namespace FluxoCaixa.Lancamentos.Domain
{
    public interface ILancamentoRepository : IRepository<Lancamento>
    {
        Task<IEnumerable<Lancamento>> ObterTodosAsNoTrackingAsync(CancellationToken cancellationToken);
        Task<Lancamento> ObterPorIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken);

        Task AdicionarAsync(Lancamento produto, CancellationToken cancellationToken);
        void Atualizar(Lancamento produto);
        void Excluir(Lancamento produto);
    }
}
