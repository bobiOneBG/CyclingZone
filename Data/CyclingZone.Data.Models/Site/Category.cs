namespace CyclingZone.Data.Models.Site
{
    using System.Collections.Generic;

    using CyclingZone.Data.Common.Models;

    public class Category : BaseModel<int>
    {
        public string Name { get; set; }

        public ICollection<Subcategory> Subcategories { get; set; }
    }
}
