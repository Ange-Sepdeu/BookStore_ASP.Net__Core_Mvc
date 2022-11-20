using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project2.Models;
using project2.data;

namespace project2.Controllers
{
    [Route("[controller]/[action]")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _db;
         public CategoryController(ApplicationDBContext db)
         {
            _db = db;
         }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString()) {
                ModelState.AddModelError("name","The DispalyOrder cannot exactly match the name");
            }
            if(ModelState.IsValid){
            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
            }
            return View(obj);
        }
    public IActionResult Edit(int? id)
        {
            if(id==null || id==0) {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            if(categoryFromDb == null) {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString()) {
                ModelState.AddModelError("name","The DispalyOrder cannot exactly match the name");
            }
            if(ModelState.IsValid){
            _db.Categories.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if(id==null || id==0) {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            if(categoryFromDb == null) {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Categories.Find(id);
            if(obj == null) {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}