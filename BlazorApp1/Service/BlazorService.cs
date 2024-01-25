using RepositoryLayer.Models;
using System.Net.Http.Json;

namespace BlazorApp1.Service
{
    public class BlazorService : IBlazorService
    {
        private readonly HttpClient _httpClient;

        public BlazorService(HttpClient httpClient)
        {
            _httpClient = new HttpClient();
        }


        public async Task<IEnumerable<Product>> GetAll(){
            var products = await _httpClient.GetFromJsonAsync<IEnumerable<Product>>("https://localhost:44393/api/products/GetProducts");
            return products;
        }

    }
}
