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
        private const int ArticlesListCount = 11;
        private const int ArticlesInSubcategoryCount = 20;
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
                SubcategoryId = subcategoryId,
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
                .Take(ArticlesInSubcategoryCount)
                .Where(x => x.Subcategory.Name == subcategoryName)
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

        public Subcategory GetSubcategory(string subcategoryName)
        {
            var subcategory = this.subcategoriesRepository.All()
                .Where(x => x.Name == subcategoryName)
                .FirstOrDefault();

            return subcategory;
        }
    }
}
