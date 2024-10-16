using AutoMapper;
using DDD.Core.Handlers.SHS.RD.CGC.Core.DomainEvents;
using Ledger.Application.Products.Commands;
using Ledger.Application.Products.Queries;
using Ledger.WebServer.Contracts.Products;
using Ledger.WebServer.Contracts.Providers;
using Microsoft.AspNetCore.Mvc;

namespace Ledger.WebServer.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMessageHandler _messageHandler;
        private readonly IMapper _mapper;

        public ProductsController(IMessageHandler messageHandler, IMapper mapper)
        {
            _messageHandler = messageHandler;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var command = new ProductsFindQuery();
            var result = await _messageHandler.SendAsync(command, CancellationToken.None);
            if (result.IsFailed)
            {
                throw new Exception();
            }
            var response = _mapper.Map<IEnumerable<ProductResponse>>(result.ValueOrDefault);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var command = new ProductFindQuery(id);
            var result = await _messageHandler.SendAsync(command, CancellationToken.None);
            if (result.IsFailed)
            {
                throw new Exception();
            }
            var response = _mapper.Map<ProductResponse>(result.ValueOrDefault);
            return Ok(response);
        }

        [HttpGet("{id}/values")]
        public async Task<IActionResult> GetValues([FromRoute] string id)
        {
            var command = new ProductFindValuesQuery(id);
            var result = await _messageHandler.SendAsync(command, CancellationToken.None);
            if (result.IsFailed)
            {
                throw new Exception();
            }
            var response = _mapper.Map<Dictionary<ProviderResponse, double>>(result.ValueOrDefault);
            return Ok(response.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddRequest request)
        {
            var command = new ProductAddCommand(request.Name, request.MesureUnit);
            var result = await _messageHandler.SendAsync(command, CancellationToken.None);
            if (result.IsFailed)
            {
                throw new Exception();
            }
            var response = _mapper.Map<ProductResponse>(result.ValueOrDefault);
            return Ok(response);
        }


    }
}
