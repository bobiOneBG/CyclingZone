namespace CyclingZone.Services.Data.Site
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using CyclingZone.Data.Common.Repositories;
    using CyclingZone.Data.Models.Site;
    using CyclingZone.Services.Mapping;

    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> categoriesRepository;

        public CategoriesService(IRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var categories = this.categoriesRepository.All().To<T>().ToList();
            return categories;
        }
    }
}
