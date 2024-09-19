using DDD.Core.Handlers;
using DDD.Core.Messages;
using FluentResults;
using Ledger.Domain.Providers;
using Ledger.Domain.Providers.Interfaces;

namespace Ledger.Application.Providers
{
    public record ProviderAddCommand(string Name) : ICommand<Result<Provider>>;

    public class ProviderAddCommandHandler : ICommandHandler<ProviderAddCommand, Result<Provider>>
    {
        private readonly IProviderRepository _repository;

        public ProviderAddCommandHandler(IProviderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Provider>> Handle(ProviderAddCommand request, CancellationToken cancellationToken)
        {
            var provider = Provider.Create(request.Name);
            await _repository.CreateAsync(provider, cancellationToken);
            return provider;
        }
    }
}
