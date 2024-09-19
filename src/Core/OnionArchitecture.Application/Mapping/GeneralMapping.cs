using AutoMapper;
using OnionArchitecture.Application.Features.Commands;
using OnionArchitecture.Application.Features.Queries.GetProductById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Mapping;

public class GeneralMapping:Profile
{
    public GeneralMapping()
    {
        CreateMap<Domain.Entities.Product,Dtos.ProductViewDto>().ReverseMap();


        CreateMap<Domain.Entities.Product, CreateProductCommand>().ReverseMap();

        CreateMap<Domain.Entities.Product, GetProductByIdViewModel>().ReverseMap();
    }
}
