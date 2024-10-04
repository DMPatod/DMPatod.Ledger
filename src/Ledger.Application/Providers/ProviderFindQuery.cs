using DDD.Core.Handlers;
using DDD.Core.Messages;
using FluentResults;
using Ledger.Domain;
using Ledger.Domain.Providers;

namespace Ledger.Application.Providers
{
    public record ProviderFindQuery() : IResultCommand<IEnumerable<Provider>>;

    public class ProviderFindQueryHandler : IResultComandHandler<ProviderFindQuery, IEnumerable<Provider>>
    {
        private readonly UnitOfWork _unitOfWork;

        public ProviderFindQueryHandler(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<Provider>>> Handle(ProviderFindQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ProviderRepository.FindAsync(cancellationToken);
            return result.ToList();
        }
    }
}
