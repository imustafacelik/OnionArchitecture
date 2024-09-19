using AutoMapper;
using MediatR;
using OnionArchitecture.Application.Dtos;
using OnionArchitecture.Application.Interfaces.Repository;
using OnionArchitecture.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Features.Queries.GetAllProducts;

public class GetAllProductQuery : IRequest<ServiceResponse<List<ProductViewDto>>>
{



    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, ServiceResponse<List<ProductViewDto>>>
    {

        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public GetAllProductQueryHandler(IProductRepository productRepository,IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper=mapper;
        }

        public async Task<ServiceResponse<List<ProductViewDto>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetAllAsync();
            var viewModel=mapper.Map<List<ProductViewDto>>(products);


            var dto = products.Select(i => new ProductViewDto()
            {
                Id = i.Id,
                Name = i.Name,
            }).ToList();

            return new ServiceResponse<List<ProductViewDto>>(viewModel);
        }
    }
}

