using ShooppyMegaMall.Core.Entities;
using ShooppyMegaMall.Core.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShooppyMegaMall.Core.Specifications
{
    public sealed class CategoryWithProductsSpecification : BaseSpecification<Category>
    {
        public CategoryWithProductsSpecification(int categoryId)
            : base(b => b.Id == categoryId)
        {
            AddInclude(b => b.Products);
        }
    }    
}
