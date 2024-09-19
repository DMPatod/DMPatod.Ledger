using DDD.Core.Handlers;
using DDD.Core.Messages;
using FluentResults;
using Ledger.Domain.Products;
using Ledger.Domain.Products.Interfaces;
using Ledger.Domain.Tickets.Enums;

namespace Ledger.Application.Products
{
    public record ProductAddCommand(string Name, MesureUnit MesureUnit) : ICommand<Result<Product>>;

    public class ProductCreateCommandHandler : ICommandHandler<ProductAddCommand, Result<Product>>
    {
        private readonly IProductRepository _repository;

        public ProductCreateCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Product>> Handle(ProductAddCommand request, CancellationToken cancellationToken)
        {
            var product = Product.Create(request.Name, request.MesureUnit);
            await _repository.CreateAsync(product, cancellationToken);
            return product;
        }
    }
}
