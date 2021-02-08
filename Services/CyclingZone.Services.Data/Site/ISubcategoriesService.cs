namespace CyclingZone.Services.Data.Site
{
    using System.Collections.Generic;

    using CyclingZone.Data.Models.Site;

    public interface ISubcategoriesService
    {
        IEnumerable<T> GetAll<T>();

        Subcategory GetSubcategory(string subcategoryName);
    }
}
