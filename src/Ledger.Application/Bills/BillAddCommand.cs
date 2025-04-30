using DDD.Core.Handlers;
using DDD.Core.Messages;
using FluentResults;
using Ledger.Domain.Bills;
using Ledger.Domain.Bills.Interfaces;
using Ledger.Domain.Providers.Interfaces;
using Ledger.Domain.Providers.ValueObjects;
using Ledger.Domain.Tickets.Enums;

namespace Ledger.Application.Bills;

public record BillAddCommand(
    string Provider,
    DateOnly Date,
    DateOnly DueDate,
    double Value,
    Currency Currency = Currency.BRL) : ICommand<Result<Bill>>;

internal class BillAddCommandHandler(IBillRepository repository,
                                     IProviderRepository providerRepository) : ICommandHandler<BillAddCommand, Result<Bill>>
{
    public async Task<Result<Bill>> Handle(BillAddCommand request, CancellationToken cancellationToken)
    {
        if (Guid.TryParse(request.Provider, out var providerId))
        {
            throw new Exception("Invalid passed GUID");
        }
        var provider = await providerRepository.FindAsync(ProviderId.Create(providerId), cancellationToken)
            ?? throw new Exception("Unable to find Provider");

        var bill = Bill.Create(provider, request.Date, request.DueDate, request.Value, request.Currency);
        await repository.AddAsync(bill, cancellationToken);

        return bill;
    }
}