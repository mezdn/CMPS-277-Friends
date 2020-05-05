using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Friends.Models;
using Friends.Storage;

namespace Friends.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoriesStore _categoriesStore;

        public CategoriesController(CategoriesStore categoriesStore)
        {
            _categoriesStore = categoriesStore;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            // TODO #8: done
            // <query> Select all Categories </query>
            // <output> List of Categories </output>

            List<Category> categories = await _categoriesStore.GetCategories();
            return View(categories);
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _categoriesStore.GetCategory((int)id);
            // TODO #9: done
            // <query> Select all properties of a Category of ID `id` </query>
            // <input> id </input>
            // <output> Category </output>

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,AreaOfExpertiseName")] Category category)
        {
            if (ModelState.IsValid)
            {
                // TODO #10: Done
                // <query> Create a new Category given its properties </query>
                // <input> Category(ID, Name, AreaOfExpertiseName) </input>
                await _categoriesStore.CreateCategory(category);
                
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
    }
}
