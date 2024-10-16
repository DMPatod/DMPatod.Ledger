using DDD.Core.Handlers;
using DDD.Core.Handlers.SHS.RD.CGC.Core.DomainEvents;
using DDD.Core.Messages;
using FluentResults;
using Ledger.Domain;
using Ledger.Domain.Products.ValueObjects;
using Ledger.Domain.Providers;

namespace Ledger.Application.Products.Queries
{
    public record ProductFindValuesQuery(string Id, DateOnly? StartDate = null, DateOnly? EndDate = null) : IResultCommand<Dictionary<Provider, double>>;

    public class ProductFindValuesQueryHandler : IResultComandHandler<ProductFindValuesQuery, Dictionary<Provider, double>>
    {
        private readonly IMessageHandler _messageHandler;
        private readonly UnitOfWork _unitOfWork;

        public ProductFindValuesQueryHandler(IMessageHandler messageHandler, UnitOfWork unitOfWork)
        {
            _messageHandler = messageHandler;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Dictionary<Provider, double>>> Handle(ProductFindValuesQuery request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.FindAsync(
                ProductId.Create(Guid.Parse(request.Id)),
                cancellationToken);
            if (product is null)
            {
                return Result.Fail("Product not found.");
            }

            var tickets = await _unitOfWork.TicketRepository.FindAsync(cancellationToken);

            return await _unitOfWork.ProductService.GetProductPricesAcrossProviders(product, tickets);
        }
    }
}
