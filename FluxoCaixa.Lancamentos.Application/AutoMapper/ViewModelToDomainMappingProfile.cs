using AutoMapper;
using FluxoCaixa.Lancamentos.Application.ViewModels;
using FluxoCaixa.Lancamentos.Domain;

namespace FluxoCaixa.Lancamentos.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<LancamentoViewModel, Lancamento>()
                .ConstructUsing(p =>
                    new Lancamento(p.Valor, p.TipoLancamento, p.DataRecebimento));
        }
    }
}