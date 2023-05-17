using FluxoCaixa.Core.Data;
using FluxoCaixa.Core.DomainObjects;
using FluxoCaixa.Lancamentos.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FluxoCaixa.Lancamentos.Data.Repository
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly LancamentoContext _context;

        public LancamentoRepository(LancamentoContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Lancamento>> ObterTodosAsNoTrackingAsync(CancellationToken cancellationToken)
            => await _context.Lancamentos.AsNoTracking().ToListAsync(cancellationToken);

        public async Task<Lancamento> ObterPorIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken)
            => await _context.Lancamentos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        public async Task AdicionarAsync(Lancamento lancamento, CancellationToken cancellationToken)
            => await _context.Lancamentos.AddAsync(lancamento, cancellationToken);

        public void Atualizar(Lancamento lancamento)
            => _context.Lancamentos.Update(lancamento);

        public void Excluir(Lancamento lancamento)
            => _context.Lancamentos.Remove(lancamento);

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}