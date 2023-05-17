using System.ComponentModel.DataAnnotations;

namespace FluxoCaixa.Lancamentos.Domain
{
    public enum TipoLancamento : byte
    {
        [Display(Name = "Débito")]
        Debito = 0,

        [Display(Name = "Crédito")]
        Credito = 1,
    }
}
