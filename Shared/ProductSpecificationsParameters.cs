using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ProductSpecificationsParameters
    {
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public ProductSpecificationsSort? Sort { get; set; }
    }

    public enum ProductSpecificationsSort
    {
        NameAsc,
        NameDesc,
        PriceAsc,
        PriceDesc
    }
}
