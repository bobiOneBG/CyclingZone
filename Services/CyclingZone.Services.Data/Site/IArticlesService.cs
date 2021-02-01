namespace CyclingZone.Services.Data.Site
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IArticlesService
    {
        Task<int> CreateAsync(
            string title,
            string subtitle,
            string author,
            string content,
            string imageUrl,
            int categoryId,
            int subcategoryId);

        IEnumerable<T> GetAll<T>();

        T GetLatest<T>();
    }
}
