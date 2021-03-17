namespace CyclingZone.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using CyclingZone.Services.Data;
    using CyclingZone.Services.Data.Site;
    using CyclingZone.Web.ViewModels.Administration.Dashboard;
    using CyclingZone.Web.ViewModels.Site.Articles;
    using CyclingZone.Web.ViewModels.Site.Categories;
    using CyclingZone.Web.ViewModels.Site.Subcategories;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : AdministrationController
    {
        private readonly ISettingsService settingsService;
        private readonly IArticlesService articlesService;
        private readonly ICategoriesService categoriesService;
        private readonly ISubcategoriesService subcategoriesService;

        public DashboardController(
            ISettingsService settingsService,
            IArticlesService articlesService,
            ICategoriesService categoriesService,
            ISubcategoriesService subcategoriesService)
        {
            this.settingsService = settingsService;
            this.articlesService = articlesService;
            this.categoriesService = categoriesService;
            this.subcategoriesService = subcategoriesService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel { SettingsCount = this.settingsService.GetCount(), };
            return this.View(viewModel);
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
            return this.Redirect(string.Join("/", "https://localhost:44319/Articles/ById", articleId));
        }
    }
}
