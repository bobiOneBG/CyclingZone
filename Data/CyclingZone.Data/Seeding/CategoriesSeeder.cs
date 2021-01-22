namespace CyclingZone.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CyclingZone.Data.Common.Enums;
    using CyclingZone.Data.Models.Site;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var categories = Enum.GetNames(typeof(EnumCategories));

            foreach (var categoryName in categories)
            {
                await dbContext.AddAsync(new Category
                {
                    Name = categoryName,
                });
            }

            return;
        }
    }
}
