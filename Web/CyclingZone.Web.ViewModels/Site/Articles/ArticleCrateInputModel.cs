namespace CyclingZone.Web.ViewModels.Site.Articles
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;

    using CyclingZone.Web.ViewModels.Site.Categories;
    using CyclingZone.Web.ViewModels.Site.Subcategories;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class ArticleCrateInputModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Subtitle { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Range(1, int.MaxValue)]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Range(1, int.MaxValue)]
        [Display(Name = "Subcategory")]
        public int SubcategoryId { get; set; }

        public IEnumerable<CategoriesDropdownViewModel> Categories { get; set; }

        public IEnumerable<SelectListItem> SelectCategories =>
            this.Categories?.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString(), Disabled = true });

        public IEnumerable<SubcategoriesDropdownViewModel> Subcategories { get; set; }

        public IEnumerable<SelectListItem> SelectSubcategories =>
            this.Subcategories?.Select(x => new SelectListItem { Text = x.Name, Value = x.JoinedIds, Disabled = true });
    }
}
