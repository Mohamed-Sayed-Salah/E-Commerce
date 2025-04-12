using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Services.Abstractions;
using Services.Specifications;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService(IUnitOfWork _unitOfWork,IMapper _mapper) : IProductService
    {
        public async Task<IEnumerable<BrandResultDTO>> GetAllBrandsAsync()
        {
            var brands = await _unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
            var brandsResult = _mapper.Map<IEnumerable<BrandResultDTO>>(brands);
            return brandsResult;
        }

        public async Task<IEnumerable<ProductResultDTO>> GetAllProductsAsync(ProductSpecificationsParameters parameters)
        {
            var products = await _unitOfWork.GetRepository<Product, int>().GetAllWithSpecificationsAsync(new ProductWithBrandAndTypeSpecifications(parameters));
            var productsResult = _mapper.Map<IEnumerable<ProductResultDTO>>(products);
            return productsResult;
        }

        public async Task<IEnumerable<TypeResultDTO>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            var typesResult = _mapper.Map<IEnumerable<TypeResultDTO>>(types);
            return typesResult;
        }

        public async Task<ProductResultDTO?> GetProductByIdAsync(int id)
        {

            var product = await _unitOfWork.GetRepository<Product, int>().GetByIdWithSpecificationsAsync(new ProductWithBrandAndTypeSpecifications(id));
            var productResult = _mapper.Map<ProductResultDTO>(product);
            return productResult;
        }
    }
}
