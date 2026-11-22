using ALPS.Application.DTO;
using ALPS.Domain.Entities;
using AutoMapper;

namespace ALPS.API.Mappers
{
    public class FornecedorProfile: Profile
    {
        public FornecedorProfile()
        {
            CreateMap<Fornecedor, FornecedorDTO>().ReverseMap();
        }
    }
}
