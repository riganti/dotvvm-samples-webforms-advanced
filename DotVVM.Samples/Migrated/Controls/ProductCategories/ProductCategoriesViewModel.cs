using DotVVM.Framework.ViewModel;
using DotVVM.Samples.Facades;
using DotVVM.Samples.Migrated.Pages;
using DotVVM.Samples.Model;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DotVVM.Samples.Migrated.Controls.ProductCategories
{
    public class ProductCategoriesViewModel : SiteViewModel
    {
        private readonly ProductDetailFacade _facade;

        [FromQuery("productId")]
        public int ProductId { get; set; }

        public bool SortDescending { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();

        public string ValidationMessageSpanText { get; private set; }
        public string NewCategoryTextBoxText { get; set; }

        public SelectItem[] SortingOptions { get; } =
            new SelectItem[] {
                new SelectItem { Text = "Ascending", Value = false },
                new SelectItem { Text = "Descending", Value = true },
            };


        public ProductCategoriesViewModel()
        {
            _facade = new ProductDetailFacade();
        }

        public void DataBind()
        {
            PrepareCategories();

            ValidateCategories();

            BindControlData();
        }

        public List<Category> GetCategories()
        {
            return Categories.OrderBy(c => c.Id).ToList();
        }

        public void AddButtonClick()
        {
            Categories.Add(new Category
            {
                Id = Categories.Count + 1,
                Name = NewCategoryTextBoxText
            });
            NewCategoryTextBoxText = "";

            ValidateCategories();
            BindControlData();
        }

        private void ValidateCategories()
        {
            foreach (var category in Categories)
            {
                category.IsError =
                    string.IsNullOrEmpty(category.Name)
                    || Categories.Any(c => c.Id != category.Id && string.Equals(c.Name, category.Name));
            }
        }

        private void BindControlData()
        {
            if (Categories.Any(c => c.IsError))
            {
                ValidationMessageSpanText = "Some categories are invalid";
            }
        }

        private void PrepareCategories()
        {
            if (!Context.IsPostBack)
            {
                Categories = ProductId > 0
                    ? _facade.GetCategories(ProductId)
                    : new List<Category>();
            }

            Categories = SortDescending
                ? Categories.OrderByDescending(x => x.Name).ToList()
                : Categories.OrderBy(x => x.Name).ToList();
        }
    }
}