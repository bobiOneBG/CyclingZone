namespace CyclingZone.Data.Models.Site
{
    using System.Collections.Generic;

    public class Category
    {
        public string Name { get; set; }

        public ICollection<Subcategory> Subcategories { get; set; }
    }
}
