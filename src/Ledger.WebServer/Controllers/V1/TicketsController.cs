﻿using AutoMapper;
using Confluent.Kafka;
using DDD.Core.Handlers.SHS.RD.CGC.Core.DomainEvents;
using Ledger.Application.Tickets;
using Ledger.Domain.Tickets.Messages;
using Ledger.WebServer.Contracts.Tickets;
using Microsoft.AspNetCore.Mvc;

namespace Ledger.WebServer.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly IMessageHandler _messageHandler;
        private readonly IMapper _mapper;

        public TicketsController(IMessageHandler messageHandler, IMapper mapper)
        {
            _messageHandler = messageHandler;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketAddRequest request)
        {
            var command = new TicketAddCommand(
                request.Provider,
                DateOnly.FromDateTime(DateTime.Parse(request.Date)),
                request.Orders.Select(o => new OrderItem(
                    o.Product,
                    o.Value,
                    o.Amount)),
                request.Installments,
                request.Currency,
                request.Direction);
            var result = await _messageHandler.SendAsync(command, CancellationToken.None);
            // if (result.IsFailed)
            // {
            //     throw new Exception();
            // }
            return Ok(result.ValueOrDefault);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new TicketFindQuery();
            var result = await _messageHandler.SendAsync(query, CancellationToken.None);
            if (result.IsFailed)
            {
                throw new Exception();
            }
            var response = _mapper.Map<IEnumerable<TicketResponse>>(result.ValueOrDefault);
            return Ok(response);
        }
    }
}
