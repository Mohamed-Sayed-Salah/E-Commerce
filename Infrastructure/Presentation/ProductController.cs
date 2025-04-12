using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(IServiceManager _serviceManager) : ControllerBase
    {


        #region Get All Products 

        [HttpGet("Products")]
        public async Task<ActionResult<IEnumerable<ProductResultDTO>>> GetAllProducts([FromQuery] ProductSpecificationsParameters parameters )
        {
            var products = await _serviceManager.ProductService.GetAllProductsAsync( parameters);

            return Ok(products);
        }

        #endregion

        #region Get All Brands

        [HttpGet("Brands")]
        public async Task<ActionResult<IEnumerable<BrandResultDTO>>> GetAllBrands()
        {
            var brands = await _serviceManager.ProductService.GetAllBrandsAsync();

            return Ok(brands);
        }

        #endregion

        #region Get All Types

        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<BrandResultDTO>>> GetAllTypes()
        {
            var types = await _serviceManager.ProductService.GetAllTypesAsync();

            return Ok(types);
        }

        #endregion

        #region Get Product By Id

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResultDTO>> GetProductById(int id)
        {
            var product = await _serviceManager.ProductService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        #endregion

    }

}
