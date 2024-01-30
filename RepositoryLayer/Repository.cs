using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Core;
using RepositoryLayer.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _db;

        public Repository(AppDbContext db)
        {
            _db = db;
        }

        public Task<IQueryable<Product>> GetProducts()
        {
            return Task.FromResult(_db.Product.AsQueryable());
        }

        public async Task<Product> AddProduct(Product product)
        {
            _db.Product.Add(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProduct(int productId)
        {
            var productToDelete = await _db.Product.FindAsync(productId);
            if (productToDelete != null)
            {
                _db.Product.Remove(productToDelete);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<Product> GetProductById(int productId)
        {
            return await _db.Product.FindAsync(productId);
        }

        public async Task UpdateProduct(Product product)
        {
            _db.Entry(product).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
