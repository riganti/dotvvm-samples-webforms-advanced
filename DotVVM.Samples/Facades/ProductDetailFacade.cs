using DotVVM.Samples.Model;
using System.Collections.Generic;
using System.Linq;

namespace DotVVM.Samples.Facades
{
    public class ProductDetailFacade
    {
        private static readonly Dictionary<int, List<Tag>> Tags = new Dictionary<int, List<Tag>>()
        {
            { 1, new List<Tag> { new Tag { Name = "New" }, new Tag { Name= "Style"} } },
            { 2, new List<Tag> { new Tag { Name = "Grilling" }, new Tag { Name= "Non-stick"}, new Tag { Name = "Easy to use"} } },
            { 3, new List<Tag> { new Tag { Name = "Wood" }, new Tag { Name= "Retro"}, new Tag { Name = "Discount"} } }
        };

        private static readonly Dictionary<int, List<Category>> Categories = new Dictionary<int, List<Category>>()
        {
            { 1, new List<Category> { new Category { Name = "Appliences", Id =0 }, new Category { Name= "Kitchen", Id = 3 }, new Category { Name = "Home", Id = 1 } } },
            { 2, new List<Category> { new Category { Name = "Appliences", Id = 0 }, new Category { Name= "Garden", Id = 2 }, new Category{ Name = "Home", Id = 1 } } },
            { 3, new List<Category> { new Category { Name = "Furniture", Id = 4 }, new Category { Name= "Garden", Id = 2 }, new Category { Name = "Home", Id = 1 } } }
        };

        public List<Tag> GetTags(int productId)
        {
            return Tags[productId];
        }

        public List<Category> GetCategories(int productId)
        {
            return Categories[productId];
        }

        public void SaveCategories(int productId, List<Category> categories)
        {
            Categories[productId] = categories;
        }
    }
}