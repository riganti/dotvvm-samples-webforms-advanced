using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Samples.Migrated.Pages.Products.Controls;
using DotVVM.Samples.Model;
using DotVVM.Samples.Pages;

namespace DotVVM.Samples.Migrated.Pages.Products
{
    public class ProductsViewModel : SiteViewModel
    {
        private readonly ProductFacade facade;

        public List<Product> Products { get; set; }
        public ProductDialogViewModel Dialog { get; set; } = new ProductDialogViewModel();

        public ProductsViewModel()
        {
            facade = new ProductFacade();
        }

        public override Task PreRender()
        {
            if(!Context.IsPostBack) {
                Products = facade.List().ToList();
            }
            return base.PreRender();
        }
    }
}

