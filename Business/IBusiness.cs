﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BusinessLayer
{
    public interface IBusiness
    {
        Task<List<ProductVM>> GetProducts();
        Task<int> AddProduct(ProductVM product);
        Task DeleteProduct(int productId);
        Task UpdateProduct(int productId, ProductVM updatedProduct);
        Task<ProductVM> GetProductById(int productId);
    }
}
