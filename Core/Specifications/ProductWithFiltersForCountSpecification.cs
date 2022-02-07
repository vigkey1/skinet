using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecPrams productFilter)
           : base(x =>
            (string.IsNullOrEmpty(productFilter.Search) || x.Name.ToLower().Contains(productFilter.Search)) &&
            (!productFilter.BrandId.HasValue || x.ProductBrandId == productFilter.BrandId) &&
            (!productFilter.TypeId.HasValue || x.ProductTypeId == productFilter.TypeId)

           )
        {



        }



    }
}
