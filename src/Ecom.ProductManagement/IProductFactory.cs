using Ecom.ProductManagement.Commands;

namespace Ecom.ProductManagement
{
    public interface IProductFactory
    {
        Product Create(ICreateProductCommand command);
    }
}