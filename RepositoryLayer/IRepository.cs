using RepositoryLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public interface IRepository
    {
        Task<IQueryable<Product>> GetProducts();
        Task<Product> AddProduct(Product product);
        Task DeleteProduct(int productId);
        Task<Product> GetProductById(int productId);
        Task UpdateProduct(Product product);

    }
}
