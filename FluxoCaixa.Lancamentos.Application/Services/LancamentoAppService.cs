using AutoMapper;
using FluxoCaixa.Core.DomainObjects;
using FluxoCaixa.Lancamentos.Application.ViewModels;
using FluxoCaixa.Lancamentos.Domain;
using System.Linq.Expressions;

namespace FluxoCaixa.Lancamentos.Application.Services
{
    public class LancamentoAppService : ILancamentoAppService
    {
        private readonly ILancamentoRepository _lancamentoRepository;
        private readonly IMapper _mapper;

        public LancamentoAppService(ILancamentoRepository lancamentoRepository,
                                 IMapper mapper)
        {
            _lancamentoRepository = lancamentoRepository;
            _mapper = mapper;
        }

        public async Task<LancamentoViewModel> ObterPorIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken)
            => _mapper.Map<LancamentoViewModel>(await _lancamentoRepository.ObterPorIdAsNoTrackingAsync(id, cancellationToken));

        public async Task<IEnumerable<LancamentoViewModel>> ObterTodosAsNoTrackingAsync(CancellationToken cancellationToken)
            => _mapper.Map<IEnumerable<LancamentoViewModel>>(await _lancamentoRepository.ObterTodosAsNoTrackingAsync(cancellationToken));

        public async Task AdicionarAsync(LancamentoViewModel lancamentoViewModel, CancellationToken cancellationToken)
        {
            var lancamento = _mapper.Map<Lancamento>(lancamentoViewModel);
            await _lancamentoRepository.AdicionarAsync(lancamento, cancellationToken);

            await _lancamentoRepository.UnitOfWork.CommitAsync(cancellationToken);
        }

        public async Task AtualizarAsync(LancamentoViewModel lancamentoViewModel, CancellationToken cancellationToken)
        {
            var lancamento = _mapper.Map<Lancamento>(lancamentoViewModel);
            _lancamentoRepository.Atualizar(lancamento);

            await _lancamentoRepository.UnitOfWork.CommitAsync(cancellationToken);
        }

        public async Task ExcluirAsync(LancamentoViewModel lancamentoViewModel, CancellationToken cancellationToken)
        {
            var lancamento = _mapper.Map<Lancamento>(lancamentoViewModel);
            _lancamentoRepository.Excluir(lancamento);

            await _lancamentoRepository.UnitOfWork.CommitAsync(cancellationToken);
        }

        public void Dispose()
        {
            _lancamentoRepository?.Dispose();
        }
    }
}