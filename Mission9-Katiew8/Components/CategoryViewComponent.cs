using Microsoft.AspNetCore.Mvc;
using Mission9_Katiew8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_Katiew8.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private Repository repo { get; set; }

        public CategoryViewComponent (Repository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["bookCategory"];
            var categories = repo.Bookz
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(categories);
        }

    }
}
