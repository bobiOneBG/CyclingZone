namespace CyclingZone.Services.Data.Site
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CyclingZone.Data.Common.Repositories;
    using CyclingZone.Data.Models.Site;
    using CyclingZone.Services.Mapping;

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

        public IEnumerable<T> GetAll<T>()
        {
            var articles = this.articlesRepository.All().To<T>().Take(11).ToList();

            return articles;
        }

        public T GetLatest<T>()
        {
            var latestArticle = this.articlesRepository.All().To<T>().First();

            return latestArticle;
        }
    }
}
