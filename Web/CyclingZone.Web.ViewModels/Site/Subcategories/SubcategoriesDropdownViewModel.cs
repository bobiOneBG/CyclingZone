namespace CyclingZone.Web.ViewModels.Site.Subcategories
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CyclingZone.Data.Models.Site;
    using CyclingZone.Services.Mapping;

    public class SubcategoriesDropdownViewModel : IMapFrom<Subcategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public string JoinedIds => string.Join(string.Empty, this.CategoryId, this.Id);
    }
}
