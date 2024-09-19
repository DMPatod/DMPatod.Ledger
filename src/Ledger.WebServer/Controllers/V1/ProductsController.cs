using DDD.Core.Handlers.SHS.RD.CGC.Core.DomainEvents;
using Ledger.Application.Products;
using Ledger.WebServer.Contracts.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ledger.WebServer.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMessageHandler _messageHandler;

        public ProductsController(IMessageHandler messageHandler)
        {
            _messageHandler = messageHandler;
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
            return Ok(result.ValueOrDefault);
        }
    }
}
