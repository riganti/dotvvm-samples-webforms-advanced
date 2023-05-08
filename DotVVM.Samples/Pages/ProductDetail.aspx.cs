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
        public List<Category> Categories { get; set; }
        public Product Product { get; set; }
        public bool SortCategoriesDesc { get; set; }
        public string Message { get; set; }

        public int CategoryCount => Categories?.Count ?? 0;


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

            if (!IsPostBack)
            {
                Categories = _facade.GetCategories(_productId);
            }
            else
            {
                Categories = ParseCategories().ToList();
            }
            BindData();
        }

        private void BindData()
        {
            ProductTagsControl.Tags = Tags;
            ProductTagsControl.DataBind();

            CategoryRepeater.DataSource = Categories;
            CategoryRepeater.DataBind();
        }

        private IEnumerable<Category> ParseCategories()
        {
            var context = HttpContext.Current;
            var tagCount = context.GetIntQuery("CategoryCount");
            for (int i = 0; i < tagCount; i++)
            {
                yield return new Category
                {
                    Id = context.GetIntQuery($"categoryId_{i}"),
                    Name = context.GetQuery($"categoryName_{i}")
                };
            }
        }

        protected void AddCategoryButton_Click(object sender, EventArgs e)
        {

        }

        protected void Save_Click(object sender, EventArgs e)
        {
        }
    }
}