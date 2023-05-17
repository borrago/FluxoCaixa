using FluxoCaixa.Lancamentos.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FluxoCaixa.WebApp.MVC.Utils
{
    public static class Dropdown
    {
        public static SelectList GetTipoLancamento()
        {
            return new SelectList(Enum.GetValues(typeof(TipoLancamento))
                .Cast<TipoLancamento>()
                .Select(v => new SelectListItem
                {
                    Text = v.GetDisplay(),
                    Value = ((int)v).ToString()
                })
                .ToList(), "Value", "Text");
        }
    }
}
