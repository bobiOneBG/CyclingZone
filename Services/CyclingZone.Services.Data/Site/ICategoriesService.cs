namespace CyclingZone.Services.Data.Site
{
    using System.Collections.Generic;

    public interface ICategoriesService
    {
        IEnumerable<T> GetAll<T>();

        string GetCategoryName(int categoryId);
    }
}
