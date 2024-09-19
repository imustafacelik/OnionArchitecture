using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Application.Dtos;
using OnionArchitecture.Application.Features.Commands;
using OnionArchitecture.Application.Features.Queries.GetAllProducts;
using OnionArchitecture.Application.Features.Queries.GetProductById;
using OnionArchitecture.Application.Interfaces.Repository;

namespace OnionArchitecture.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly  IMediator mediatr;

        public ProductsController(IMediator mediator)
        {
            this.mediatr = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllProductQuery();

            return Ok(await mediatr.Send(query));        
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommand command)
        {
            return Ok(mediatr.Send(command));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetProductByIdQuery();

            return Ok(await mediatr.Send(query));
        }

    }
}
