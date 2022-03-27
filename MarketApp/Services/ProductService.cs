using MarketApp.DataTransferObject;
using MarketApp.Models;

namespace MarketApp.Services
{
    public class ProductService : IProductService
    {
        private readonly MarketDbContext _context;
        public ProductService(MarketDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AddProduct(ProductDto productDto)
        {
            Product product = new Product();
            product.Name = productDto.Name;
            product.Price = productDto.Price;
            product.Description = productDto.Description;
            _context.Products?.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async IAsyncEnumerable<Product> GetAllProducts()
        {
            var products = _context.Products?.AsAsyncEnumerable();
            await foreach (Product product in products)
            {
                yield return product;
            }
        }

        public async Task<Product> GetById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product is null)
            {
                throw new NullReferenceException();
            }
            return product;
        }

        public async Task RemoveProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product is null)
            {
                throw new NullReferenceException();
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateProduct(int id, ProductDto productDto)
        {
            var currentProduct = await _context.Products.FindAsync(id);
            if (currentProduct is null)
            {
                return false;
            }
            currentProduct.Name = productDto.Name;
            currentProduct.Description = productDto.Description;
            currentProduct.Price = productDto.Price;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
