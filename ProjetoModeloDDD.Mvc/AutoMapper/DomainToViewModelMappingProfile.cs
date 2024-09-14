
using AutoMapper;
using ProjetoModeloDDD.Mvc.ViewModels;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Mvc.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }
         
        protected override void Configure()
        {
            Mapper.CreateMap<ClienteViewModel,Cliente>();
            Mapper.CreateMap<ProdutoViewModel,Produto>();
        }
    }
}