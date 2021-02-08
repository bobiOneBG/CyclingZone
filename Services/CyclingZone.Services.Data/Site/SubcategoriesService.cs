namespace CyclingZone.Services.Data.Site
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using CyclingZone.Data.Common.Repositories;
    using CyclingZone.Data.Models.Site;
    using CyclingZone.Services.Mapping;

    public class SubcategoriesService : ISubcategoriesService
    {
        private readonly IRepository<Subcategory> subcategoriesRepository;
        private readonly IRepository<Category> categoriesRepository;

        public SubcategoriesService(
            IRepository<Subcategory> subcategoriesRepository,
            IRepository<Category> categoriesRepository)
        {
            this.subcategoriesRepository = subcategoriesRepository;
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var subcategories = this.subcategoriesRepository.All().To<T>().ToList();
            return subcategories;
        }

        public Subcategory GetSubcategory(string subcategoryName)
        {
            var subcategory = this.subcategoriesRepository.All()
                .Where(x => x.Name == subcategoryName)
                .FirstOrDefault();

            return subcategory;
        }
    }
}
