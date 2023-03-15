using Microsoft.AspNetCore.Mvc;
using WaterProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterProject.Components
{
    public class TypesViewComponent: ViewComponent
    {
        private IWaterProjectRepository repo { get; set; }

        public TypesViewComponent (IWaterProjectRepository temp)
        {
            repo = temp;
        }
        public  IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["projectHi"];
            var types = repo.Books.Select(x => x.Category).Distinct().OrderBy(x => x);

            return View(types);
        }
    }
}
