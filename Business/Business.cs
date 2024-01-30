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
            var data = await _repo.GetProducts();

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
            var product = await _repo.GetProductById(productId);

            if (product == null)
            {
                return null; 
            }

            var productVM = _mapper.Map<ProductVM>(product);
            return productVM;
        }


    }
}
