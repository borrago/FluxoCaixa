using FluxoCaixa.Lancamentos.Domain;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FluxoCaixa.Lancamentos.Application.ViewModels
{
    [Display(Name = "Lançamentos")]
    public class LancamentoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Valor { get; set; }

        [Display(Name = "Data de Recebimento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataRecebimento { get; set; }

        [Display(Name = "Tipo de Lançamento")]
        [EnumDataType(typeof(TipoLancamento), ErrorMessage = "O campo {0} é obrigatório")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TipoLancamento TipoLancamento { get; set; }
    }
}
