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
        IQueryable<Product> GetProducts();
        //IQueryable<Product> GetProducts();
        Task<Product> AddProduct(Product product);
        Task DeleteProduct(int productId);
        Task<Product> GetProductById(int productId);
        Task UpdateProduct(Product product);

        IQueryable<Order> GetOrders();
        Task<List<Order>> GetOrderById(int productId);
        Task<List<Order>> GetOrdersByProductId(int productId);
        Task<Order> AddOrder(Order order);
        Task DeleteOrder(int orderId);
    }
}
