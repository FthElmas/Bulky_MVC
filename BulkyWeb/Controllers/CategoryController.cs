using Microsoft.AspNetCore.Mvc;
using BulkyWeb.Data;
using BulkyWeb.Models;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _db;
        public CategoryController(ApplicationDBContext db)
        {
            this._db = db;
        }
        public IActionResult Index()
        {
            List<Category> objectCategoryList = _db.Categories.ToList();
            return View(objectCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString() )
            {
                ModelState.AddModelError("name", "The Display Order cannot exactly match the Name.");
            }
            if(ModelState.IsValid)
            {
               _db.Categories.Add(obj);
               _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Delete(Category obj)
        {
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
