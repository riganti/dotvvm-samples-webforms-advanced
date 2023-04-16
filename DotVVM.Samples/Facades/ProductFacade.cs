using DotVVM.Samples.Model;
using System.Collections.Generic;
using System.Linq;

namespace DotVVM.Samples.Pages
{
    public class ProductFacade
    {
        public static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Code = "PR001", Name = "Soap", Description = "Good soap", Price = 3 },
            new Product { Id = 2, Code = "PR002", Name = "Desinfectiion", Description = "For clean hands", Price = 6 },
            new Product { Id = 3, Code = "PR003", Name = "Razor", Description = "For great shave", Price = 2 }
        };

        public Product Get(int id) => products.FirstOrDefault(p => p.Id == id);
        public IReadOnlyList<Product> List() => products;
    }
}