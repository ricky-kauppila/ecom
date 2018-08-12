using Ecom.ProductManagement.Commands;

namespace Ecom.ProductManagement
{
    internal interface IProductFactory
    {
        Product Create(CreateProductCommand command);
    }
}