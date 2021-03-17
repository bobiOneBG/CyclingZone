namespace CyclingZone.Services.Data.Site
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CyclingZone.Data.Common.Repositories;
    using CyclingZone.Data.Models.Site;
    using CyclingZone.Services.Mapping;

    public class ArticlesService : IArticlesService
    {
        private const int ArticlesListCount = 11;
        private const int ArticlesViewCount = 20;
        private readonly IDeletableEntityRepository<Article> articlesRepository;
        private readonly IRepository<Subcategory> subcategoriesRepository;
        private readonly IRepository<Category> categoriesRepository;

        public ArticlesService(
            IDeletableEntityRepository<Article> articlesRepository,
            IRepository<Subcategory> subcategoriesRepository)
        {
            this.articlesRepository = articlesRepository;
            this.subcategoriesRepository = subcategoriesRepository;
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

                // Joined CategoryId and SubcategoryId In ArticleCreateInputModel
                SubcategoryId = this.RemoveFirstDigit(subcategoryId),
            };

            await this.articlesRepository.AddAsync(article);
            await this.articlesRepository.SaveChangesAsync();
            return article.Id;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var articles = this.articlesRepository.All()
                .OrderByDescending(x => x.CreatedOn)
                .To<T>()
                .Take(ArticlesListCount)
                .ToList();

            return articles;
        }

        public IEnumerable<T> GetAllBySubcategory<T>(string subcategoryName)
        {
            var articles = this.articlesRepository.All()
                .OrderByDescending(x => x.CreatedOn)
                .Take(ArticlesViewCount)
                .Where(x => x.Subcategory.Name == subcategoryName)
                .To<T>()
                .ToList();

            return articles;
        }

        public IEnumerable<T> GetAllByCategory<T>(string categoryName)
        {
            var articles = this.articlesRepository.All()
                  .OrderByDescending(x => x.CreatedOn)
                  .Take(ArticlesViewCount)
                  .Where(x => x.Category.Name == categoryName)
                  .To<T>()
                  .ToList();

            return articles;
        }

        public T GetById<T>(int id)
        {
            var article = this.articlesRepository.All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return article;
        }

        private int RemoveFirstDigit(int subcategoryId)
        {
            return int.Parse(subcategoryId.ToString().Substring(1));
        }
    }
}
