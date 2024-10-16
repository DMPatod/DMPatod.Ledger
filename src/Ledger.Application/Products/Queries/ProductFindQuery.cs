using DDD.Core.Handlers;
using DDD.Core.Messages;
using FluentResults;
using Ledger.Domain.Products;
using Ledger.Domain.Products.Interfaces;
using Ledger.Domain.Products.ValueObjects;

namespace Ledger.Application.Products.Queries
{
    public record ProductFindQuery(string Id) : IResultCommand<Product>;

    public class ProductFindQueryHandler : IResultComandHandler<ProductFindQuery, Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductFindQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<Product>> Handle(ProductFindQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.FindAsync(
                ProductId.Create(Guid.Parse(request.Id)),
                cancellationToken);

            if (product is null)
            {
                return Result.Fail("Product not found.");
            }

            return product;
        }
    }
}
