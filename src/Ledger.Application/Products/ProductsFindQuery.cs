using DDD.Core.Handlers;
using DDD.Core.Messages;
using FluentResults;
using Ledger.Domain.Products;
using Ledger.Domain.Products.Interfaces;

namespace Ledger.Application.Products
{
    public record ProductsFindQuery() : IResultCommand<IEnumerable<Product>>;

    public class ProductsFindQueryHandler : IResultComandHandler<ProductsFindQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public ProductsFindQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<IEnumerable<Product>>> Handle(ProductsFindQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.FindAsync(cancellationToken);
            return products.ToList();
        }
    }
}
