using FluxoCaixa.Lancamentos.Application.Services;
using FluxoCaixa.Lancamentos.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.WebApp.MVC.Controllers
{
    [Authorize]
    public class LancamentoController : Controller
    {
        private readonly ILancamentoAppService _lancamentoAppService;

        public LancamentoController(ILancamentoAppService lancamentoAppService)
        {
            _lancamentoAppService = lancamentoAppService;
        }

        // GET: Lancamento
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
            => View(await _lancamentoAppService.ObterTodosAsNoTrackingAsync(cancellationToken));

        // GET: Lancamento/Details/5
        public async Task<IActionResult> Details(Guid id, CancellationToken cancellationToken)
            => View(await _lancamentoAppService.ObterPorIdAsNoTrackingAsync(id, cancellationToken));

        // GET: Lancamento/Create
        public IActionResult Create()
            => View();

        // POST: Lancamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Valor,DataRecebimento,TipoLancamento")] LancamentoViewModel lancamentoViewModel, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(lancamentoViewModel);

            await _lancamentoAppService.AdicionarAsync(lancamentoViewModel, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        // GET: Lancamento/Edit/5
        public async Task<IActionResult> Edit(Guid id, CancellationToken cancellationToken)
            => View(await _lancamentoAppService.ObterPorIdAsNoTrackingAsync(id, cancellationToken));

        // POST: Lancamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Valor,DataRecebimento,TipoLancamento")] LancamentoViewModel lancamentoViewModel, CancellationToken cancellationToken)
        {
            if (id != lancamentoViewModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(lancamentoViewModel);

            await _lancamentoAppService.AtualizarAsync(lancamentoViewModel, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        // GET: Lancamento/Delete/5
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
            => View(await _lancamentoAppService.ObterPorIdAsNoTrackingAsync(id, cancellationToken));

        // POST: Lancamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, CancellationToken cancellationToken)
        {
            var lancamento = await _lancamentoAppService.ObterPorIdAsNoTrackingAsync(id, cancellationToken);
            await _lancamentoAppService.ExcluirAsync(lancamento, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
    }
}
