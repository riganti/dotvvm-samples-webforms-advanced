using DotVVM.Samples.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotVVM.Samples.Migrated.Controls.ProductCategories
{
    public class ProductCategoriesViewModel
    {
        public bool SortDescending { get; set; }
        public SelectItem[] SortingOptions { get; } =
            new SelectItem[] {
                new SelectItem { Text = "Ascending", Value = false },
                new SelectItem { Text = "Descending", Value = true },
            };
    }
}