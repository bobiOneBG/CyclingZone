namespace CyclingZone.Data.Models.Forum
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CyclingZone.Data.Common.Models;

    public class ForumCategory : BaseModel<int>
    {
        public string Title { get; set; }

        public IEnumerable<Discussion> Discussions { get; set; }
    }
}
