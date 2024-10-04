using AutoMapper;
using Ledger.Domain.Products;

namespace Ledger.WebServer.Contracts.Products
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResponse>();
        }
    }
}
