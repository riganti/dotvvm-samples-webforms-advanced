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
        private readonly ProductDetailFacade _facade;
        private bool sortDescending;

        public int ProductId { get; set; }
        protected List<Category> Categories { get; private set; } = new List<Category>();

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
            return Categories.OrderBy(c=> c.Id).ToList();
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
                Categories = ReadCategories().ToList();
            }

            sortDescending = HttpContext.Current.GetBoolQuery("desc");

            Categories = sortDescending 
                ? Categories.OrderByDescending(x => x.Name).ToList() 
                : Categories.OrderBy(x => x.Name).ToList();
        }

        private IEnumerable<Category> ReadCategories()
        {
            foreach (RepeaterItem item in CategoryRepeater.Items)
            {
                var idField = (HiddenField)item.FindControl("CategoryIdField");
                var textField = (TextBox)item.FindControl("CategoryNameField");

                yield return new Category
                {
                    Id = int.TryParse(idField.Value, out var id) ? id : 0,
                    Name = textField.Text
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

        public string GetSortSelect()
        {
            return GetSelectControl("desc",
                sortDescending,
                new SelectItem[] {
                    new SelectItem { Text = "Ascending", Value = false },
                    new SelectItem { Text = "Descending", Value = true },
                });
        }

        public string GetSelectControl(string name, object selectedValue, IList<SelectItem> items)
        {
            return $@"
				<select
					name=""{name}""
				>{string.Concat(items.Select(t => GetOption(
                        selectedValue == t.Value,
                        t.Value,
                        t.Text))
                )}</select>";
        }

        private string GetOption(
            bool isSelected,
            object value,
            string text,
            string tooltip = "")
        {
            var selected = isSelected ? "selected" : "";
            var description = HttpUtility.HtmlEncode(text);
            var title = !string.IsNullOrEmpty(tooltip) ? $"title=\"{tooltip}\"" : "";

            return $@"<option value={value} {selected} {title}>{description}</option>";
        }

        
    }
}