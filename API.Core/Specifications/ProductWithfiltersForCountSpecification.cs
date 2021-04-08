using API.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.Specifications
{
    public class ProductWithfiltersForCountSpecification:BaseSpecification<Product>
    {
        public ProductWithfiltersForCountSpecification(ProductSpecParams productSpecParams):
            base(x=> (!productSpecParams.BrandId.HasValue || x.ProductBrandId == productSpecParams.BrandId) &&
            (!productSpecParams.TypeId.HasValue || x.ProductTypeId == productSpecParams.TypeId) &&
            (string.IsNullOrWhiteSpace(productSpecParams.Search) || x.Name.ToLower().Contains(productSpecParams.Search)))
        {

        }
    }
}
