using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterProject.Models;
using System.Diagnostics;
using WaterProject.Models.ViewModels;

namespace WaterProject.Controllers
{
    public class HomeController : Controller
    {

        private IWaterProjectRepository repo;

        public HomeController(IWaterProjectRepository temp)
        {
            repo = temp;
        }
        public IActionResult Index(string projectHi, int pageNum = 1)
        {
            int pageSize = 10;
            var x = new ProjectsViewModel
            {
                Books = repo.Books.Where(p => p.Category == projectHi || projectHi == null).OrderBy(p => p.Title).Skip((pageNum - 1) * pageSize).Take(pageSize),
                PageInfo = new PageInfo
                {
                    TotalNumProjects = (projectHi == null ?
                    repo.Books.Count() :
                    repo.Books.Where(x => x.Category == projectHi).Count()),
                    ProjectsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
