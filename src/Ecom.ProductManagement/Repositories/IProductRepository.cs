using System.Threading.Tasks;

namespace Ecom.ProductManagement.Repositories
{
    internal interface IProductRepository
    {
        Task Save(Product product);
    }
}