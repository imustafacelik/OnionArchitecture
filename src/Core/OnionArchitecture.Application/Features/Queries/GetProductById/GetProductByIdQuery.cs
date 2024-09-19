﻿using AutoMapper;
using MediatR;
using OnionArchitecture.Application.Dtos;
using OnionArchitecture.Application.Interfaces.Repository;
using OnionArchitecture.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Features.Queries.GetProductById;

public class GetProductByIdQuery:IRequest<ServiceResponse<GetProductByIdViewModel>>    
{

    public Guid Id { get; set; }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ServiceResponse<GetProductByIdViewModel>>
    {
        IProductRepository productRepository;
        private readonly IMapper mapper;

        public GetProductByIdQueryHandler(IProductRepository productRepository,IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<GetProductByIdViewModel>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {

            var product = await productRepository.GetByIdAsync(request.Id);

            var dto = mapper.Map <GetProductByIdViewModel> (product);

            return new ServiceResponse<GetProductByIdViewModel>(dto);
            
        }
    }
}
