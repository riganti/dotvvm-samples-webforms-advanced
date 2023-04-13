using System;
using System.Threading.Tasks;
using System.Web.Hosting;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DotVVM.Samples.Startup))]

namespace DotVVM.Samples
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseDotVVM<DotvvmStartup>(HostingEnvironment.ApplicationPhysicalPath);
        }
    }
}
