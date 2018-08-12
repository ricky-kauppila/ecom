using Ecom.ProductManagement.Commands;

namespace Ecom.ProductManagement
{
    public class ProductFactory : IProductFactory
    {
        public Product Create(ICreateProductCommand command)
        {
            return new Product(command.Id,command.ArticleNumber);
        }
    }
}