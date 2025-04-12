using Domain.Contracts;
using Domain.Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    public class ProductWithBrandAndTypeSpecifications : Specifications<Product>
    {
        public ProductWithBrandAndTypeSpecifications(int id) : base(P => P.Id == id)
        {
            AddInclude(P => P.productBrand);
            AddInclude(P => P.productType);
        }
        public ProductWithBrandAndTypeSpecifications(ProductSpecificationsParameters parameters)
            : base(product =>
            (
            (!parameters.BrandId.HasValue || product.BrandId == parameters.BrandId.Value) &&
            (!parameters.TypeId.HasValue || product.TypeId == parameters.TypeId.Value)
            ))
        {
            AddInclude(P => P.productBrand);
            AddInclude(P => P.productType);

            if (parameters.Sort is not null)
            {
                switch (parameters.Sort)
                {
                    case ProductSpecificationsSort.NameAsc:
                        SetOrderBy(P => P.Name);
                        break;
                    case ProductSpecificationsSort.NameDesc:
                        SetOrderByDescending(P => P.Name);
                        break;
                    case ProductSpecificationsSort.PriceAsc:
                        SetOrderBy(P => P.Price);
                        break;
                    case ProductSpecificationsSort.PriceDesc:
                        SetOrderByDescending(P => P.Price);
                        break;

                }
            }

        }
    }
}
