using System.Threading.Tasks;

namespace Ecom.ProductManagement.Repositories
{
    public interface IProductRepository
    {
        Task Save(Product product);
    }
}