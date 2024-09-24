using Ledger.Domain.Products;
using Ledger.Domain.Products.Enums;
using Ledger.Domain.Providers;
using Ledger.Domain.Tickets.Enums;
using Ledger.WebServer.Contracts.Orders;
using Ledger.WebServer.Contracts.Products;
using Ledger.WebServer.Contracts.Providers;
using Ledger.WebServer.Contracts.Tickets;
using Ledger.WebServer.Controllers.V1;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Ledger.WebServer.Tests.V1
{
    public class TicketsControllerTests
    {
        private readonly WebApplicationFactory<TicketsController> _applicationFactory;

        public TicketsControllerTests()
        {
            _applicationFactory = new WebApplicationFactory<TicketsController>();
        }

        [Fact]
        public async Task HappyPath()
        {
            var client = _applicationFactory.CreateClient();

            var prodiverResponse = await client.PostAsJsonAsync(
                "api/Providers",
                new ProvidersAddRequest("Pão de Açuca"));
            Assert.True(prodiverResponse.IsSuccessStatusCode);
            var provider = JsonConvert.DeserializeObject<Provider>(await prodiverResponse.Content.ReadAsStringAsync());
            Assert.NotNull(provider);

            var products = new Dictionary<string, string>()
            {
                { "Batata Doce", "" },
                { "File Suino", "" },
                { "Monster", "" }
            };
            foreach (var item in products)
            {
                if (string.IsNullOrEmpty(item.Value))
                {
                    var productsResponse = await client.PostAsJsonAsync(
                        "api/Products",
                        new ProductAddRequest(item.Key, MesureUnit.Kilogram));
                    Assert.True(productsResponse.IsSuccessStatusCode);
                    var product = JsonConvert.DeserializeObject<Product>(await productsResponse.Content.ReadAsStringAsync());
                    Assert.NotNull(product);
                    products[item.Key] = product.Id.Value.ToString();
                }
            }

            var response = await client.PostAsJsonAsync(
                "api/Tickets",
                new TicketAddRequest(
                    provider.Id.ToString(),
                    "09/13/2024",
                    [
                        new OrderCreateRequest(products["Batata Doce"], 5.39, 2.35),
                        new OrderCreateRequest(products["File Suino"], 24.9, 1.055),
                        new OrderCreateRequest(products["File Suino"], 24.9, 1.16),
                        new OrderCreateRequest(products["Monster"], 9.49, 2)
                    ],
                    1,
                    Currency.BRL,
                    Direction.Outcome));
        }
    }
}
