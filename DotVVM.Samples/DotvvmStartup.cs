using DotVVM.Framework.Configuration;
using DotVVM.Framework.ResourceManagement;
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
        }

        private void RegisterControls(DotvvmConfiguration config, string applicationPath)
        {
            
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
        }
    }
}