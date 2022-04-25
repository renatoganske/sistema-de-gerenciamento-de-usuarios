using AutoMapper;
using LyncasAPI.DTO;
using LyncasAPI.Models;

namespace LyncasAPI.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<UsuarioDTO, Pessoa>()
                .ForPath(x => x.autenticacao.Status, x => x.MapFrom(x => x.Status))
                .ForPath(x => x.autenticacao.Senha, x => x.MapFrom(x => x.Senha))
                .ReverseMap();

            CreateMap<Pessoa, UsuarioResponseDTO>()
                .ForMember(x => x.Status, x => x.MapFrom(x => x.autenticacao.Status))
                .ReverseMap();

            CreateMap<UsuarioDTO, Pessoa>()
               .ForPath(x => x.autenticacao.Status, x => x.MapFrom(x => x.Status))
               .ForPath(x => x.autenticacao.Senha, x => x.MapFrom(x => x.Senha))
               .ReverseMap();
        }
    }
}
