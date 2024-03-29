using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PackerTracker.Models;

namespace PackerTracker.Controllers
{
    public class CategoriesController : Controller
    {
        [HttpGet("/categories")]
        public ActionResult Index()
        {
            List<Category> allCategories = Category.GetAll();
            return View(allCategories);
        }

        [HttpGet("/categories/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/categories")]
        public ActionResult Create(string categoryName)
        {
            Category newCategory = new Category(categoryName);
            return RedirectToAction("Index");
        }

        [HttpGet("/categories/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Category selectedCategory = Category.Find(id);
            List<Item> categoryItems = selectedCategory.Items;
            model.Add("category", selectedCategory);
            model.Add("items", categoryItems);
            return View(model);
        }

        [HttpPost("/categories/{categoryId}/items")]
        public ActionResult Create(int categoryId, string itemDescription, string itemName)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Category foundCategory = Category.Find(categoryId);
            Item newItem = new Item(itemDescription, itemName);
            foundCategory.AddItem (newItem);
            List<Item> categoryItems = foundCategory.Items;
            model.Add("items", categoryItems);
            model.Add("category", foundCategory);
            return View("Show", model);
        }
    }
}
