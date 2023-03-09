using Microsoft.AspNetCore.Mvc;
using Mission9_Katiew8.Models;
using Mission9_Katiew8.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_Katiew8.Controllers
{
    public class HomeController : Controller
    {

        private Repository repo;

        public HomeController(Repository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string bookCategory, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new ProjectViewModel
            {
                Books = repo.Bookz
                .Where(p => p.Category == bookCategory || bookCategory == null)
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumProjects = (bookCategory == null
                        ? repo.Bookz.Count()
                        : repo.Bookz.Where(x => x.Category == bookCategory).Count()),
                    ProjectsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };


            return View(x);
        }

    }
}
