using DotVVM.Samples.Facades;
using DotVVM.Samples.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotVVM.Samples.Pages
{
    public partial class ProductDetail : System.Web.UI.Page
    {
        private readonly ProductDetailFacade _facade;
        private readonly ProductFacade _productFacade;
        private int _productId;

        public List<Tag> Tags { get; set; } = new List<Tag>();
        public Product Product { get; set; }
        public string Message { get; set; }

        public ProductDetail()
        {
            _facade = new ProductDetailFacade();
            _productFacade = new ProductFacade();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var context = HttpContext.Current;

            _productId = context.GetIntQuery($"productId");

            if (_productId == 0)
            {
                Message = "Invalid product ID";
                return;
            }

            Tags = _facade.GetTags(_productId);
            Product = _productFacade.Get(_productId);

            BindData();
        }

        private void BindData()
        {
            ProductTagsControl.Tags = Tags;
            ProductTagsControl.ProductId = _productId;
            ProductTagsControl.DataBind();

            ProductCategoriesControl.ProductId = _productId;
            ProductCategoriesControl.DataBind();
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            var categories = ProductCategoriesControl.GetCategories();

            if (!categories.Any(c => c.IsError))
            {
                _facade.SaveCategories(_productId, categories);
            }
            else
            {
                Message = "Cannot save.";
            }
        }
    }
}