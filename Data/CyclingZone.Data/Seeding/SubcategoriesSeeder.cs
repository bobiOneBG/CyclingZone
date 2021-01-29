namespace CyclingZone.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CyclingZone.Data.Common.Enums;
    using CyclingZone.Data.Models.Site;

    public class SubcategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Subcategories.Any())
            {
                return;
            }

            var categoryValues = Enum.GetValues(typeof(EnumCategories));

            var subcategoryValues = Enum.GetValues(typeof(EnumSubcategories));

            foreach (var categoryValue in categoryValues)
            {
                foreach (var subcategoryValue in subcategoryValues)
                {
                    var sbcFirstDigit = GetFirstDigit((int)subcategoryValue);

                    if (sbcFirstDigit == (int)categoryValue)
                    {
                        var subcategoryName = Enum.GetName(typeof(EnumSubcategories), subcategoryValue);

                        await dbContext.Subcategories.AddAsync(
                            new Subcategory
                            {
                                Name = subcategoryName,
                                CategoryId = sbcFirstDigit,
                                Id = (int)subcategoryValue,
                            });
                    }
                }
            }
        }

        private static int GetFirstDigit(int subcategoryValue)
        {
            while (subcategoryValue >= 10)
            {
                subcategoryValue /= 10;
            }

            return subcategoryValue;
        }
    }
}
