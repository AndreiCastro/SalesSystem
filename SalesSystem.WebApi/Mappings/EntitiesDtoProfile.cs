using AutoMapper;
using SalesSystem.WebApi.Dtos;
using SalesSystem.WebApi.Model;

namespace SalesSystem.WebApi.Mappings
{
    public class EntitiesDtoProfile : Profile
    {
        public EntitiesDtoProfile()
        {
            CreateMap<ClienteModel, ClienteDto>().ReverseMap();
            CreateMap<ProdutoModel, ProdutoDto>().ReverseMap();
            CreateMap<VendaModel, VendaDto>().ReverseMap();                
        }
    }
}
