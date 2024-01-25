using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Core;
using RepositoryLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public async Task<IEnumerable<Product>> GetProducts()
        {
          return await _db.Product.ToListAsync();

          //  var abc = new List<Product>();
        //    return abc;
        }
    }
}
