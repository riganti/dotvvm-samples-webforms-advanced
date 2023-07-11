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
using System.Web.Services.Description;
using DotVVM.Samples.Facades;

namespace DotVVM.Samples.Migrated.Pages.ProductDetail
{
    public class ProductDetailViewModel : SiteViewModel
    {
        private readonly ProductDetailFacade _facade;

        public string Message { get; private set; }

        [FromQuery("productId")]
        public int ProductId { get; set; }
        public List<Tag> Tags { get; set; }
        public ProductCategoriesViewModel Categories { get; set; } = new ProductCategoriesViewModel();

        public ProductDetailViewModel()
        {
            _facade = new ProductDetailFacade();
        }

        public override Task Load()
        {
            Categories.DataBind();
            return base.PreRender();
        }

        public void Save()
        {
            var categories = Categories.GetCategories();

            if (!categories.Any(c => c.IsError))
            {
                _facade.SaveCategories(ProductId, categories);
            }
            else
            {
                Message = "Cannot save.";
            }
        }
    }
}

