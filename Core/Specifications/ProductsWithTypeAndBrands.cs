using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
   public class ProductsWithTypeAndBrands :BaseSpecification<Product>
    {
        public ProductsWithTypeAndBrands(ProductSpecPrams productFilter)
            :base(x=>
             (string.IsNullOrEmpty(productFilter.Search) || x.Name.ToLower().Contains(productFilter.Search)) && 
            (!productFilter.BrandId.HasValue || x.ProductBrandId == productFilter.BrandId) &&
            (!productFilter.TypeId.HasValue || x.ProductTypeId == productFilter.TypeId)
            
            )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            ApplyPaging(productFilter.PageSize * (productFilter.PageIndex - 1),productFilter.PageSize);

            if (!string.IsNullOrEmpty(productFilter.Sort))
            {
                switch (productFilter.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDecending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                    
                }

            }



        }

        public ProductsWithTypeAndBrands(int Id) 
            : base(x=>x.Id == Id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}
