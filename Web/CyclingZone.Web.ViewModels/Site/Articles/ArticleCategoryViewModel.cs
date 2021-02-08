namespace CyclingZone.Web.ViewModels.Site.Articles
{
    using CyclingZone.Data.Models.Site;
    using CyclingZone.Services.Mapping;

    public class ArticleCategoryViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string ImageUrl { get; set; }
    }
}
