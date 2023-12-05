using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatG02.Core.Entities;

namespace TalabatG02.Core.Specifications
{
    public class ProductsWithFiltrationForCountSpecification : BaseSpecification<Product>
    {
        public ProductsWithFiltrationForCountSpecification(ProductSpecParams specParams)//Get
           : base(P =>
           (!specParams.BrandId.HasValue || P.ProductBrandId == specParams.BrandId) &&
           (!specParams.TypeId.HasValue || P.ProductTypeId == specParams.TypeId)
           )
        {
            

         

        }
    }
}
