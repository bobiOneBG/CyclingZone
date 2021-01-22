namespace CyclingZone.Data.Models.Site
{
    using System.Collections.Generic;

    using CyclingZone.Data.Common.Models;

    public class Subcategory : BaseModel<int>
    {
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
