using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using RepositoryLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels;

namespace BusinessLayer
{
    public class Business : IBusiness
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        public Business(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
           
        }

        public async Task<List<ProductVM>> GetProducts()
        {
            // Await the Task<IQueryable<Product>> to get the actual IQueryable<Product>
            var data =  _repo.GetProducts();

            // Use ToListAsync on the IQueryable<Product> result
            var products = await data.ToListAsync();

            // Use _mapper.Map to map the data to ProductVM
            var productVMs = _mapper.Map<List<ProductVM>>(products);

            return productVMs;
        }

        public async Task<int> AddProduct(ProductVM product)
        {
            var data = _mapper.Map<ProductVM, Product>(product);
            var result = _repo.AddProduct(data);
            return result.Id;
        }
        public async Task DeleteProduct(int productId)
        {
            await _repo.DeleteProduct(productId);
        }

        public async Task UpdateProduct(int productId, ProductVM updatedProduct)
        {
            var existingProduct = await _repo.GetProductById(productId);

            if (existingProduct != null)
            {
                // Update properties of existingProduct with values from updatedProduct
                existingProduct.Name = updatedProduct.Name;
                existingProduct.Price = updatedProduct.Price;
                existingProduct.Description = updatedProduct.Description;

                // Save changes
                await _repo.UpdateProduct(existingProduct);
            }
        }

        public async Task<ProductVM> GetProductById(int productId)
        {
            // var product = await _repo.GetProductById(productId);
            var product = await _repo.GetProducts().Where(x => x.Id == productId).FirstOrDefaultAsync();

            if (product == null)
            {
                return null;
            }

            var productVM = _mapper.Map<ProductVM>(product);
            return productVM;
        }

        public async Task<ProductVM> GetOrderById(int id)
        {
            var data = await _repo.GetProducts().Include(x=>x.Orders).Where(x=> x.Id == id).FirstOrDefaultAsync();

         
            var products = _mapper.Map<Product, ProductVM>(data);


            return products;
        }


        public async Task<List<OrderVM>> GetOrders()
        {
      
            var data = _repo.GetOrders();

            var orders = await data.ToListAsync();

            var orderVMs = _mapper.Map<List<OrderVM>>(orders);

            return orderVMs;
        }
        public async Task<List<OrderVM>> GetOrdersByProductId(int productId)
        {
            var orders = await _repo.GetOrdersByProductId(productId);
            var orderVMs = _mapper.Map<List<OrderVM>>(orders);
            return orderVMs;
        }
        public async Task<int> AddOrder(int productId, OrderVM order)
        {
            // Validate if the product exists
            var existingProduct = await _repo.GetProductById(productId);
            if (existingProduct == null)
            {
                throw new InvalidOperationException($"Product with ID {productId} not found.");
            }

            // Validate if the order data is valid
            if (order == null)
            {
                throw new InvalidOperationException("Invalid order data.");
            }

            // Map the OrderVM to the Order model
            var orderToAdd = _mapper.Map<Order>(order);

            // Associate the order with the existing product
            orderToAdd.ProductId = productId;

            // Add the order to the repository
            var addedOrder = await _repo.AddOrder(orderToAdd);

            // You may return the ID of the added order
            return addedOrder.Id;
        }

        public async Task DeleteOrder(int orderId)
        {
            await _repo.DeleteOrder(orderId);
        }

    }
}
