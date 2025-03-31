using System.Collections.Generic;
using Fluke.Domain.Base;

namespace Fluke.Domain.Models
{
    public class CategoriesAll
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public List<Category> Categories { get; set; }
    }
}
