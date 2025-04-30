using AutoMapper;
using DDD.Core.Handlers.SHS.RD.CGC.Core.DomainEvents;
using Ledger.Application.Bills;
using Ledger.WebServer.Contracts.Bill;
using Microsoft.AspNetCore.Mvc;

namespace Ledger.WebServer.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController(IMessageHandler messageHandler, IMapper mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BillAddRequest request)
        {
            var command = new BillAddCommand(
                request.Provider,
                DateOnly.FromDateTime(DateTime.Parse(request.Date)),
                DateOnly.FromDateTime(DateTime.Parse(request.DueDate)),
                request.Value,
                request.Currency);
            var result = await messageHandler.SendAsync(command, CancellationToken.None);
            if (result.IsFailed)
            {
                throw new Exception();
            }
            return Ok(result.ValueOrDefault);
        }
    }
}
