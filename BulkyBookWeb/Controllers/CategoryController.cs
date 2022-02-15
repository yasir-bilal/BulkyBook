using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using BulkyBookWeb.Models.DAL;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers;
public class CategoryController : Controller
{

    private  _IAllRepository repository;

    public  CategoryController()
    {
        this.repository = new AllRepositroy (new ApplicationDbContext());
    }

    [ActivatorUtilitiesConstructor]

    public CategoryController(_IAllRepository dbrepository)
    {
        repository = dbrepository;
    }

    public IActionResult Index()
    {
        var objCategoryList = repository.GetAll();

        return View(objCategoryList);

    }

    //GET
    public IActionResult Create()
    {
        return View();
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category category)
    {
        if (category.Name == category.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
        }
        if (ModelState.IsValid)
        {
            repository.Insert(category);
            repository.Save();

            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index");
        }
        return View(category);
    }

    //GET
    [HttpGet]
    public IActionResult Edit(int id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var category = repository.GetById(id);
        //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
        //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category category)
    {
        if (category.Name == category.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
        }
        if (ModelState.IsValid)
        {
            repository.Update(category);
            repository.Save();
            TempData["success"] = "Category updated successfully";
            return RedirectToAction("Index");
        }
        return View(category);
    }

    public IActionResult Delete(int id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var category = repository.GetById(id);
        //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
        //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }

    //POST
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int id)
    {
        repository.Delete(id);
        repository.Save();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index");

    }
}
