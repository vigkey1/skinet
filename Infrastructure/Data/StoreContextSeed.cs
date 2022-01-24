using Core.Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
   public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var brandData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);

                    context.ProductBrands.AddRange(brands);

                }

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var Logger = loggerFactory.CreateLogger<StoreContextSeed>();
                Logger.LogError(ex.Message);
                
            }

            try
            {
                if (!context.ProductTypes.Any())
                {
                    var TypeData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var Types = JsonSerializer.Deserialize<List<ProductType>>(TypeData);

                    context.ProductTypes.AddRange(Types);

                }

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                var Logger = loggerFactory.CreateLogger<StoreContextSeed>();
                Logger.LogError(ex.Message);
            }

            try
            {
                if (!context.Products.Any())
                {
                    var ProductData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var Products = JsonSerializer.Deserialize<List<Product>>(ProductData);

                    context.Products.AddRange(Products);

                }

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                var Logger = loggerFactory.CreateLogger<StoreContextSeed>();
                Logger.LogError(ex.Message);
            }

        }
    }
}
