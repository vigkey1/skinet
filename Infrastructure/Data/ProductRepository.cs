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

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _Context.ProductBrands.ToListAsync();
         }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _Context.Products
                .Include(x=>x.ProductBrand)
                .Include(x=>x.ProductType)
                .ToListAsync();
        }

        public async Task<Product> GetProductsByIdAsync(int id)
        {
            return await _Context.Products
                .Include(x=>x.ProductBrand)
                .Include(x=>x.ProductType)
                .FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _Context.ProductTypes.ToListAsync();
        }
    }
}
