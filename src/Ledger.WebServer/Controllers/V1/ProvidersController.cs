using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProvidersController(IMessageHandler messageHandler, IMapper mapper)
        {
            _messageHandler = messageHandler;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Find()
        {
            var command = new ProviderFindQuery();
            var result = await _messageHandler.SendAsync(command, CancellationToken.None);
            if (result.IsFailed)
            {
                throw new Exception();
            }
            var response = _mapper.Map<IEnumerable<ProviderResponse>>(result.ValueOrDefault);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProviderAddRequest request)
        {
            var command = new ProviderAddCommand(request.Name);
            var result = await _messageHandler.SendAsync(command, CancellationToken.None);
            if (result.IsFailed)
            {
                throw new Exception();
            }
            var response = _mapper.Map<ProviderResponse>(result.ValueOrDefault);
            return Ok(response);
        }
    }
}
