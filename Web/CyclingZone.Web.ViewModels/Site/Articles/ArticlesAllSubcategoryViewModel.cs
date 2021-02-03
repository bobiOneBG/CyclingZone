namespace CyclingZone.Web.ViewModels.Site.Articles
{
    using System.Collections.Generic;

    using CyclingZone.Data.Models.Site;

    public class ArticlesAllSubcategoryViewModel
    {
        public Subcategory Subcategory { get; set; }

        public string CategoryName { get; set; }

        public IEnumerable<ArticleSubcategoryViewModel> Articles { get; set; }
    }
}
