using FluxoCaixa.Core.DomainObjects;
using FluxoCaixa.Lancamentos.Application.ViewModels;
using System.Linq.Expressions;

namespace FluxoCaixa.Lancamentos.Application.Services
{
    public interface ILancamentoAppService : IDisposable
    {
        Task<LancamentoViewModel> ObterPorIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<LancamentoViewModel>> ObterTodosAsNoTrackingAsync(CancellationToken cancellationToken);

        Task AdicionarAsync(LancamentoViewModel produtoViewModel, CancellationToken cancellationToken);
        Task AtualizarAsync(LancamentoViewModel produtoViewModel, CancellationToken cancellationToken);
        Task ExcluirAsync(LancamentoViewModel produtoViewModel, CancellationToken cancellationToken);
    }
}