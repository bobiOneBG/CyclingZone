namespace CyclingZone.Web.ViewModels.Site.Subcategories
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CyclingZone.Data.Models.Site;
    using CyclingZone.Services.Mapping;

    public class SubcategoriesDropdownViewModel : IMapFrom<Subcategory>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
