namespace CyclingZone.Web.Controllers
{
    using System.Threading.Tasks;

    using CyclingZone.Services.Data.Site;
    using CyclingZone.Web.ViewModels.Site.Articles;
    using CyclingZone.Web.ViewModels.Site.Categories;
    using CyclingZone.Web.ViewModels.Site.Subcategories;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ArticlesController : BaseController
    {
        private readonly ICategoriesService categoriesService;
        private readonly ISubcategoriesService subcategoriesService;
        private readonly IArticlesService articlesService;

        public ArticlesController(
            ICategoriesService categoriesService,
            ISubcategoriesService subcategoriesService,
            IArticlesService articlesService)
        {
            this.categoriesService = categoriesService;
            this.subcategoriesService = subcategoriesService;
            this.articlesService = articlesService;
        }

        // Get Articles/ById/5
        public IActionResult ById(int id)
        {
            var viewModel = this.articlesService.GetById<ArticleViewModel>(id);

            if (viewModel == null)
            {
                return this.NotFound("Article not found");
            }

            return this.View(viewModel);
        }

        // TO DO Pagination
        public IActionResult BySubcategory(string subcategoryName)
        {
            var articles = this.articlesService
                .GetAllBySubcategory<ArticleSubcategoryViewModel>(subcategoryName);

            var subcategory = this.articlesService.GetSubcategory(subcategoryName);

            var categoryName = this.categoriesService.GetCategoryName(subcategory.CategoryId);

            var viewModel = new ArticlesAllSubcategoryViewModel
            {
                CategoryName = categoryName,
                Subcategory = subcategory,
                Articles = articles,
            };

            return this.View(viewModel);
        }
    }
}
