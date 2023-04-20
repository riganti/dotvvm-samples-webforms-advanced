using DotVVM.Framework.Configuration;
using DotVVM.Framework.ResourceManagement;
using DotVVM.Samples.Migrated.Pages.Products;
using Microsoft.Extensions.DependencyInjection;

namespace DotVVM.Samples
{
    public class DotvvmStartup : IDotvvmStartup, IDotvvmServiceConfigurator
    {
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {
            RegisterRoutes(config, applicationPath);
            RegisterControls(config, applicationPath);
            RegisterResources(config, applicationPath);
        }

        private void RegisterRoutes(DotvvmConfiguration config, string applicationPath)
        {
            config.RouteTable.Add("CustomerNotes", "CustomerNotes", "Migrated/Pages/CustomerNotes/CustomerNotes.dothtml");
            config.RouteTable.Add("Products", "Products", "Migrated/Pages/Products/Products.dothtml");
        }

        private void RegisterControls(DotvvmConfiguration config, string applicationPath)
        {
            config.Markup.AddMarkupControl("cc", "ProductDialog", "Migrated/Pages/Products/Controls/ProductDialog.dotcontrol");
        }

        private void RegisterResources(DotvvmConfiguration config, string applicationPath)
        {
            config.Resources.Register("site-css", new StylesheetResource()
            {
                Location = new UrlResourceLocation("~/Content/site.css")
            });
        }

        public void ConfigureServices(IDotvvmServiceCollection services)
        {
            services.Services.AddTransient<ProductsUiSetvice>();
        }
    }
}