namespace CyclingZone.Web.ViewModels.Site.Articles
{
    using CyclingZone.Data.Models.Site;
    using CyclingZone.Services.Mapping;

    public class ArticleListViewModel : IMapFrom<Article>
    {
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string CategoryName { get; set; }
    }
}
