namespace CyclingZone.Services.Data.Site
{
    using System.Threading.Tasks;

    using CyclingZone.Data.Common.Repositories;
    using CyclingZone.Data.Models.Site;

    public class ArticlesService : IArticlesService
    {
        private readonly IDeletableEntityRepository<Article> articlesRepository;

        public ArticlesService(IDeletableEntityRepository<Article> articlesRepository)
        {
            this.articlesRepository = articlesRepository;
        }

        public async Task<int> CreateAsync(string title, string subtitle, string author, string content,
            string imageUrl, int categoryId, int subcategoryId)
        {
            var article = new Article
            {
                Title = title,
                Subtitle = subtitle,
                Author = author,
                Content = content,
                ImageUrl = imageUrl,
                CategoryId = categoryId,
                SubcategoryId = subcategoryId,
            };

            await this.articlesRepository.AddAsync(article);
            await this.articlesRepository.SaveChangesAsync();
            return article.Id;
        }
    }
}
