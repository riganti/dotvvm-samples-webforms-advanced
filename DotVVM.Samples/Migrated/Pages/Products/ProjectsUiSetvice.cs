using DotVVM.Framework.ViewModel;
using DotVVM.Samples.Migrated.Pages.Products.Controls;
using DotVVM.Samples.Pages;

namespace DotVVM.Samples.Migrated.Pages.Products
{
    public class ProductsUiSetvice
    {
        private readonly ProductFacade facade;

        public ProductsUiSetvice()
        {
            facade = new ProductFacade();
        }

        [AllowStaticCommand]
        public ProductDialogViewModel GetDialog(int id)
        {
            var product = facade.Get(id);

            return new ProductDialogViewModel
            {
                Code = product.Code,
                Description = product.Description,
                IsVisible = true,
                Name = product.Name,
                Price = product.Price
            };
        }
    }
}

