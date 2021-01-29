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

        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            var categories = this.categoriesService.GetAll<CategoriesDropdownViewModel>();
            var subcategories = this.subcategoriesService.GetAll<SubcategoriesDropdownViewModel>();

            var viewModel = new ArticleCrateInputModel
            {
                Categories = categories,
                Subcategories = subcategories,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create(ArticleCrateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var articleId = await this.articlesService.CreateAsync(input.Title, input.Subtitle, input.Author,
                input.Content, input.ImageUrl, input.CategoryId, input.SubcategoryId);

            // To do -Redirect to created article
            return this.RedirectToAction("Index", "Home", articleId);
        }
    }
}
