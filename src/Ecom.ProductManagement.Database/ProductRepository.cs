using System;
using System.Threading.Tasks;
using Ecom.ProductManagement.Repositories;

namespace Ecom.ProductManagement.Database
{
    public class ProductRepository : IProductRepository
    {
        public async Task Save(Product product)
        {
            await Console.Out.WriteLineAsync("Product saved");
        }
    }
}