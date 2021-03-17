namespace CyclingZone.Data.Models.Forum
{
    using System.Collections.Generic;

    using CyclingZone.Data.Common.Models;

    public class Discussion : BaseDeletableModel<int>
    {
        public string Title { get; set; }

        public ForumCategory ForumCategory { get; set; }

        public IEnumerable<Post> Posts { get; set; }
    }
}
