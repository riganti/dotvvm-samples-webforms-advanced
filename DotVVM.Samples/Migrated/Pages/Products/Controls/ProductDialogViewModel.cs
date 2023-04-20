using DotVVM.Framework.Binding.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotVVM.Samples.Migrated.Pages.Products.Controls
{
    public class ProductDialogViewModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public bool IsVisible { get; set; }
    }
}