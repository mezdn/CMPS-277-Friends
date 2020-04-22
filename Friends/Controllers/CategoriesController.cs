using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Friends.Models;

namespace Friends.Controllers
{
    public class CategoriesController : Controller
    {

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            // TODO #8: 
            // <query> Select all Categories </query>
            // <output> List of Categories </output>

            return View();
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = new Category();
            // TODO #9: 
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
                // TODO #10: 
                // <query> Create a new Category given its properties </query>
                // <input> Category(ID, Name, AreaOfExpertiseName) </input>

                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = new Category();
            // TODO #11: Duplicate of TODO #9 

            return View(category);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,AreaOfExpertiseName")] Category category)
        {
            if (id != category.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // TODO #12: 
                // <query> Edit an old Category given its id and the ne values of its properties </query>
                // <input> id, Category(Name, AreaOfExpertiseName) </input>
                
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // TODO #13: Duplicate of TODO #9 

            var category = new Category();
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // TODO #14: 
            // <query> Delete a category of ID `id`</query>
            // <input> id</input>

            return RedirectToAction(nameof(Index));
        }
    }
}
