namespace CyclingZone.Data.Models.Site
{
    using System.Collections.Generic;

    public class Subcategory
    {
        public string Name { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
