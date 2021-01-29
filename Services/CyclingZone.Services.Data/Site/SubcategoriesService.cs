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

        public SubcategoriesService(IRepository<Subcategory> subcategoriesRepository)
        {
            this.subcategoriesRepository = subcategoriesRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var subcategories = this.subcategoriesRepository.All().To<T>().ToList();
            return subcategories;
        }
    }
}
