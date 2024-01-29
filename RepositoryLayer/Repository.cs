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
    }
}
