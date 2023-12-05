using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TalabatG02.Core.Entities;
using TalabatG02.Core.Entities.Order_Aggregation;

namespace TalabatG02.Repository.Data
{
    public static class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext dbContext)
        {
            if(!dbContext.ProductBrands.Any()) /// one Element inside Collection
            {
                var brandsData = File.ReadAllText("../TalabatG02.Repository/Data/DataSeed/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                if (brands?.Count > 0)
                {
                    foreach (var brand in brands)
                        await dbContext.ProductBrands.AddAsync(brand);

                    await dbContext.SaveChangesAsync();
                }
            }
            if (!dbContext.ProductTypes.Any()) /// one Element inside Collection
            {
                var TypesData = File.ReadAllText("../TalabatG02.Repository/Data/DataSeed/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);

                if (types?.Count > 0)
                {
                    foreach (var type in types)
                        await dbContext.ProductTypes.AddAsync(type);

                    await dbContext.SaveChangesAsync();
                }
            }
            if (!dbContext.Products.Any()) /// one Element inside Collection
            {
                var productsData = File.ReadAllText("../TalabatG02.Repository/Data/DataSeed/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                if (products?.Count > 0)
                {
                    foreach (var product in products)
                        await dbContext.Products.AddAsync(product);

                    await dbContext.SaveChangesAsync();
                }
            }

            if (!dbContext.DeliveryMethods.Any()) /// one Element inside Collection
            {
                var MethodsData = File.ReadAllText("../TalabatG02.Repository/Data/DataSeed/delivery.json");
                var DeliveryMethods = JsonSerializer.Deserialize<List<DeliveryMethod>>(MethodsData);

                if (DeliveryMethods?.Count > 0)
                {
                    foreach (var methods in DeliveryMethods)
                        await dbContext.DeliveryMethods.AddAsync(methods);

                    await dbContext.SaveChangesAsync();
                }
            }


        }
    }
}
