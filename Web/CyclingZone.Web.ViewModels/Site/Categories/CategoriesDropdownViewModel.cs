namespace CyclingZone.Web.ViewModels.Site.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CyclingZone.Data.Models.Site;
    using CyclingZone.Services.Mapping;

    public class CategoriesDropdownViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
