using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;
using DotVVM.Samples.Model;
using DotVVM.Samples.Controls;
using DotVVM.Samples.Migrated.Controls.ProductCategories;

namespace DotVVM.Samples.Migrated.Pages.ProductDetail
{
    public class ProductDetailViewModel : SiteViewModel
    {
        public int ProductId { get; set; }
        public List<Tag> Tags { get; set; }

        public ProductCategoriesViewModel Categories { get; set; } = new ProductCategoriesViewModel();
    }
}

