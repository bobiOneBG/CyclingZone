namespace CyclingZone.Data.Models.Forum
{
    using System;

    using CyclingZone.Data.Common.Models;

    public class Post : BaseDeletableModel<int>
    {
        public string Title { get; set; }

        public ApplicationUser Author { get; set; }

        public string Content { get; set; }

        public Discussion Discussion { get; set; }
    }
}
