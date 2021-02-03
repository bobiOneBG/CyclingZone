namespace CyclingZone.Web.ViewModels.Site.Articles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CyclingZone.Data.Models.Site;
    using CyclingZone.Services.Mapping;

    public class ArticleSubcategoryViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string ImageUrl { get; set; }

        public string SubcategoryName { get; set; }
    }
}
