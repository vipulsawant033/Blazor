using RepositoryLayer.Models;

namespace BlazorApp1.Service
{
    public interface IBlazorService
    {
        Task<IEnumerable<Product>> GetAll();
    }
}
