
using AutoMapper;
using ProjetoModeloDDD.Mvc.ViewModels;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Mvc.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            // Mapeamento de Domain para ViewModel
            Mapper.CreateMap<Cliente, ClienteViewModel>();
            Mapper.CreateMap<Produto, ProdutoViewModel>();
        }
    }
}