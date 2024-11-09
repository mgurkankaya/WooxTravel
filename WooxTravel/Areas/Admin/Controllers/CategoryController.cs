using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooxTravel.Context;
using WooxTravel.Entities;

namespace WooxTravel.Areas.Admin.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        TravelContext context = new TravelContext();
        
        public ActionResult CategoryList()
        {
            var values = context.Categories.ToList();
            return View(values);
        }

        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            var values = context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("CategoryList", "Category", "Admin");
        }

        public ActionResult DeleteCategory(int id)
        {
            var value = context.Categories.Find(id);
            context.Categories.Remove(value);
            context.SaveChanges();
            return RedirectToAction("CategoryList", "Category", "Admin");
        }


        public ActionResult UpdateCategory(int id)
        {
            var value = context.Categories.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            var value = context.Categories.Find(category.CategoryId);
            value.Name = category.Name;
            category.CategoryStatus = true;
            context.SaveChanges();
            return RedirectToAction("CategoryList", "Category", "Admin");
        }
    }
}