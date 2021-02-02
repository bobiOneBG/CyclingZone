namespace CyclingZone.Web.ViewModels.Site.Articles
{
    using System;

    using CyclingZone.Data.Models.Site;
    using CyclingZone.Services.Mapping;
    using Ganss.XSS;

    public class ArticleViewModel : IMapFrom<Article>
    {
        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string ImageUrl { get; set; }

        public string CategoryName { get; set; }

        public string SubcategoryName { get; set; }
    }
}
