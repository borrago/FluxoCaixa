using FluxoCaixa.Core.Data;
using FluxoCaixa.Lancamentos.Domain;
using Microsoft.EntityFrameworkCore;

namespace FluxoCaixa.Lancamentos.Data
{
    public class LancamentoContext : DbContext, IUnitOfWork
    {
        public LancamentoContext(DbContextOptions<LancamentoContext> options) : base(options)
        {
        }

        public DbSet<Lancamento> Lancamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LancamentoContext).Assembly);
        }

        public async Task<bool> CommitAsync(CancellationToken cancellationToken)
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return await base.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
