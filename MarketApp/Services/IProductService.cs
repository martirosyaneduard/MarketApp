using MarketApp.DataTransferObject;
using MarketApp.Models;
namespace MarketApp.Services
{
    public interface IProductService
    {
        Task<Product> AddProduct(ProductDto productDto);

        IAsyncEnumerable<Product> GetAllProducts();

        Task<Product> GetById(int id);

        Task RemoveProduct(int id);

        Task<bool> UpdateProduct(int id, ProductDto productDto);
    }
}
