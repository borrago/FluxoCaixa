using AutoMapper;
using FluxoCaixa.Lancamentos.Application.ViewModels;
using FluxoCaixa.Lancamentos.Domain;

namespace FluxoCaixa.Lancamentos.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Lancamento, LancamentoViewModel>();
        }
    }
}
