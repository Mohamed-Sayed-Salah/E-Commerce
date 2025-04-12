using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResultDTO>> GetAllProductsAsync(ProductSpecificationsParameters parameters);
        Task<IEnumerable<BrandResultDTO>> GetAllBrandsAsync();
        Task<IEnumerable<TypeResultDTO>> GetAllTypesAsync();

        Task<ProductResultDTO?> GetProductByIdAsync(int id);

    }
}
