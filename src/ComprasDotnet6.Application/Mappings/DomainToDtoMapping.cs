using AutoMapper;
using ComprasDotnet6.Application.DTOs;
using ComprasDotnet6.Domain.Entities;

namespace ComprasDotnet6.Application.Mappings
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<Person, PersonDTO>();
            CreateMap<Product, ProductDTO>();
            CreateMap<Purchase, PurchaseDetailDTO>()
                .ForMember(pe => pe.Person, opt => opt.Ignore())
                .ForMember(pr => pr.Product, opt => opt.Ignore())
                .ConstructUsing((model, context) =>
                {
                    var dto = new PurchaseDetailDTO
                    {
                        Id = model.Id,
                        Person = model.Person.Name,
                        Product = model.Product.Name,
                        Date = model.Date.ToShortDateString(),
                    };
                    return dto;
                });
        }
    }
}
