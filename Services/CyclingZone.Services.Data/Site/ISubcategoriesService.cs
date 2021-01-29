namespace CyclingZone.Services.Data.Site
{
    using System.Collections.Generic;

    public interface ISubcategoriesService
    {
        IEnumerable<T> GetAll<T>();
    }
}