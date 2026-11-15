using ALPS.Application.DTO;
using ALPS.Domain.Entities;
using AutoMapper;

namespace ALPS.API.Mappers
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
    }
}
