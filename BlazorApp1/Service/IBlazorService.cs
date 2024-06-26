﻿using RepositoryLayer.Models;
using ViewModels;
using static BlazorApp1.Pages.Login;
using static BlazorApp1.Pages.Register;

namespace BlazorApp1.Service
{
    public interface IBlazorService
    {
        Task<List<ProductVM>>GetAll();
        Task<int> Add(ProductVM product);
        Task DeleteProduct(int productId);
        Task<ProductVM> GetProductById(int productId);
        Task UpdateProduct(ProductVM product);
        Task<ProductVM> GetById(int id);
        Task<List<OrderVM>> GetAllOrders();
        Task<List<OrderVM>> GetOrdersByProductId(int productId);
        Task<int> AddOrder(int productId, OrderVM order);
        Task DeleteOrder(int orderId);
        //Task<int> RegisterUser(RegisterAccountForm user);
        //Task<int> LoginUser(LoginAccountForm user);
    }
}
