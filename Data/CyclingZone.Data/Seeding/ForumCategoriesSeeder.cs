namespace CyclingZone.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CyclingZone.Data.Models.Forum;

    public class ForumCategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ForumCategories.Any())
            {
                return;
            }

            var categories = new List<string>
            {
                "Cycling Zone team",
                "Road cycling forum",
                "Commuter cycling forum",
                "Family & kids cycling forum",
                "Stolen & found bikes",
                "Buy & sell",
            };

            foreach (var category in categories)
            {
              await dbContext.ForumCategories.AddAsync(
                    new ForumCategory
                    {
                        Title = category,
                    });
            }
        }
    }
}
