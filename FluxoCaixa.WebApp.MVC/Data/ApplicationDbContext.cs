using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FluxoCaixa.Lancamentos.Application.ViewModels;

namespace FluxoCaixa.WebApp.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<FluxoCaixa.Lancamentos.Application.ViewModels.LancamentoViewModel> LancamentoViewModel { get; set; } = default!;
    }
}