




using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Persistence
{
    public class DbInitializer : IDbInitializer
    {
        private readonly StoreContext _storeContext;

        public DbInitializer(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task InitializeAsync()
        {

            #region Create Database if it doesn't Exist And Apply any pending migrations

                if (_storeContext.Database.GetPendingMigrations().Any())
                {
                   await  _storeContext.Database.MigrateAsync();
                }

            #endregion

            #region ProductTypes 

            if (!_storeContext.ProductTypes.Any())
            {
                var productTypesdData = await File.ReadAllTextAsync(@"..\Infrastructure\Presestance\Data\Seeding\types.json");

                var productTypes = JsonSerializer.Deserialize<List<ProductType>>(productTypesdData);

                if (productTypes is not null & productTypes.Any())
                {
                    await _storeContext.ProductTypes.AddRangeAsync(productTypes);
                    await _storeContext.SaveChangesAsync();
                }
            }

            #endregion

            #region ProductBrands

            if (!_storeContext.ProductBrands.Any())
            {
                var productBrandsData = await File.ReadAllTextAsync(@"..\Infrastructure\Presestance\Data\Seeding\brands.json");

                var productBrands = JsonSerializer.Deserialize<List<ProductBrand>>(productBrandsData);
                if (productBrands is not null & productBrands.Any())
                {
                    await _storeContext.ProductBrands.AddRangeAsync(productBrands);
                    await _storeContext.SaveChangesAsync();
                }
            }

            #endregion

            #region Products

            if (!_storeContext.Products.Any())
            {
                var productsData = await File.ReadAllTextAsync(@"..\Infrastructure\Presestance\Data\Seeding\products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                if (products is not null & products.Any())
                {
                    await _storeContext.Products.AddRangeAsync(products);
                    await _storeContext.SaveChangesAsync();
                }
            }

            #endregion

        }
    }
}
