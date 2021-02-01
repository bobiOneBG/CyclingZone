namespace CyclingZone.Web.ViewModels.Site.Articles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CyclingZone.Data.Models.Site;

    public class ArticlesAllViewModel
    {
        public ArticleListViewModel LatestArticle { get; set; }

        public IEnumerable<ArticleListViewModel> Articles { get; set; }
    }
}
