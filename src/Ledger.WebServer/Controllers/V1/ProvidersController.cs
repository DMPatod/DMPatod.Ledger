using DDD.Core.Handlers.SHS.RD.CGC.Core.DomainEvents;
using Ledger.Application.Providers;
using Ledger.WebServer.Contracts.Providers;
using Microsoft.AspNetCore.Mvc;

namespace Ledger.WebServer.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidersController : ControllerBase
    {
        private readonly IMessageHandler _messageHandler;

        public ProvidersController(IMessageHandler messageHandler)
        {
            _messageHandler = messageHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProvidersAddRequest request)
        {
            var command = new ProviderAddCommand(request.Name);
            var result = await _messageHandler.SendAsync(command, CancellationToken.None);
            if (result.IsFailed)
            {
                throw new Exception();
            }
            return Ok(result.ValueOrDefault);
        }
    }
}
