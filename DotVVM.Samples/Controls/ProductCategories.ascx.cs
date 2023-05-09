using DotVVM.Samples.Facades;
using DotVVM.Samples.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotVVM.Samples.Controls
{
    public partial class ProductCategories : UserControl
    {
        private ProductDetailFacade _facade;

        public int ProductId { get; set; }
        public List<Category> Categories { get; private set; } = new List<Category>();
        public bool SortCategoriesDesc { get; private set; }

        public ProductCategories()
        {
            _facade = new ProductDetailFacade();
        }

        public override void DataBind()
        {
            PrepareCategories();

            BindRepeaterData();

            base.DataBind();
        }

        private void BindRepeaterData()
        {
            CategoryRepeater.DataSource = Categories;
            CategoryRepeater.DataBind();
        }

        public List<Category> GetCategories()
        {
            return Categories;
        }

        private void PrepareCategories()
        {
            if (!IsPostBack)
            {
                Categories = ProductId > 0
                    ? _facade.GetCategories(ProductId)
                    : new List<Category>();
            }
            else
            {
                Categories = ParseCategories().ToList();
            }
        }

        private IEnumerable<Category> ParseCategories()
        {
            var context = HttpContext.Current;
            var categoryCount = context.GetIntQuery("categoryCount");
            SortCategoriesDesc = context.GetBoolQuery("desc");

            for (int i = 0; i < categoryCount; i++)
            {
                yield return new Category
                {
                    Id = context.GetIntQuery($"categoryId_{i}"),
                    Name = context.GetQuery($"categoryName_{i}")
                };
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            Categories.Add(new Category
            {
                Id = Categories.Count,
                Name = NewCategoryTextBox.Text
            });
            NewCategoryTextBox.Text = "";
            BindRepeaterData();
        }
    }
}