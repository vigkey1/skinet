using Core.Entity;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _Context;
        public ProductRepository(StoreContext context)
        {
            _Context = context;
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _Context.Products.ToListAsync();
        }

        public async Task<Product> GetProductsByIdAsync(int id)
        {
            return await _Context.Products.FindAsync(id);
        }
    }
}
