namespace CyclingZone.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class DiscussionsController : BaseController
    {
        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }
    }
}
