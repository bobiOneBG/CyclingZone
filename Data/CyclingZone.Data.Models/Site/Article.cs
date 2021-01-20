namespace CyclingZone.Data.Models.Site
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CyclingZone.Data.Common.Models;

    public class Article : BaseDeletableModel<int>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Subtitle { get; set; }

        public string Author { get; set; }

        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int SubcategoryId { get; set; }

        public virtual Subcategory Subcategory { get; set; }
    }
}
