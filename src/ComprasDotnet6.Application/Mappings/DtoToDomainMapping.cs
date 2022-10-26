using AutoMapper;
using ComprasDotnet6.Application.DTOs;
using ComprasDotnet6.Domain.Entities;

namespace ComprasDotnet6.Application.Mappings
{
    public class DtoToDomainMapping : Profile
    {
        public DtoToDomainMapping()
        {
            CreateMap<PersonDTO, Person>();
            CreateMap<ProductDTO, Product>();
        }

    }
}
