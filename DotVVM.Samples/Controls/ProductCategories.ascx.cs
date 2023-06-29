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
        private bool _sortDescending;

        public int ProductId { get; set; }
        protected List<Category> Categories { get; private set; } = new List<Category>();

        public ProductCategories()
        {
            _facade = new ProductDetailFacade();
        }

        public override void DataBind()
        {
            PrepareCategories();

            ValidateCategories();

            BindRepeaterData();

            base.DataBind();
        }

        public List<Category> GetCategories()
        {
            return Categories.OrderBy(c => c.Id).ToList();
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            Categories.Add(new Category
            {
                Id = Categories.Count + 1,
                Name = NewCategoryTextBox.Text
            });
            NewCategoryTextBox.Text = "";

            ValidateCategories();
            BindRepeaterData();
        }

        protected string GetSortSelect()
        {
            return GetSelectControl("categoriesDesc",
                _sortDescending,
                new SelectItem[] {
                    new SelectItem { Text = "Ascending", Value = false },
                    new SelectItem { Text = "Descending", Value = true },
                });
        }

        private void BindRepeaterData()
        {
            CategoryRepeater.DataSource = Categories;
            CategoryRepeater.DataBind();

            if (Categories.Any(c => c.IsError))
            {
                ValidationMessageSpan.Visible = true;
                ValidationMessageSpan.InnerText = "Some categories are invalid";
            }
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

            _sortDescending = HttpContext.Current.GetBoolQuery("categoriesDesc");

            Categories = _sortDescending
                ? Categories.OrderByDescending(x => x.Name).ToList()
                : Categories.OrderBy(x => x.Name).ToList();
        }

        public void ValidateCategories()
        {
            foreach (var category in Categories)
            {
                category.IsError = 
                    string.IsNullOrEmpty(category.Name) 
                    || Categories.Any(c => c.Id != category.Id && string.Equals(c.Name, category.Name));
            }
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

        private string GetSelectControl(string name, object selectedValue, IList<SelectItem> items)
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