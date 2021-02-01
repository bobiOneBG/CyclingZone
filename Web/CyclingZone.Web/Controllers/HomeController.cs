namespace CyclingZone.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using CyclingZone.Services.Data.Site;
    using CyclingZone.Web.ViewModels;
    using CyclingZone.Web.ViewModels.Site.Articles;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IArticlesService articlesService;

        public HomeController(IArticlesService articlesService)
        {
            this.articlesService = articlesService;
        }

        public IActionResult Index()
        {
            var articles = this.articlesService.GetAll<ArticleListViewModel>();

            var viewModel = new ArticlesAllViewModel
            {
                Articles = articles,
                LatestArticle = articles.First(),
            };

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
