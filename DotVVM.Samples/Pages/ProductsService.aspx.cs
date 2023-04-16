using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotVVM.Samples.Pages
{
    public partial class ProductsService : System.Web.UI.Page
    {
        private readonly ProductFacade facade;

        public ProductsService()
        {
            facade = new ProductFacade();
        }

        public string Json { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            var context = HttpContext.Current;
            var action = context.GetQuery("action");
            var id = context.GetIntQuery("id");

            if (action == "detail" && id > 0)
            {
                Json = JsonConvert.SerializeObject(facade.Get(id) ?? new object());
            }
            else
            {
                Json = JsonConvert.SerializeObject(facade.List());
            }
        }
    }
}