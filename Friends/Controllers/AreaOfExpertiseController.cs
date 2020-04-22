using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Friends.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Friends.Controllers
{
    public class AreaOfExpertiseController : Controller
    {
        // GET: AreaOfExpertise
        public ActionResult Index()
        {
            // TODO #15: 
            // <query> Select all areas of expertise </query>
            // <output> List of Area of expertise </output>

            return View();
        }

        // GET: AreaOfExpertise/Details/5
        public ActionResult Details(string name)
        {
            var areaOfExpertise = new AreaOfExpertise();
            // TODO #16: 
            // <query> Select all properties of a AreaOfExpertise of Name `name` </query>
            // <input> name </input>
            // <output> AreaOfExpertise </output>

            return View();
        }

        // GET: AreaOfExpertise/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AreaOfExpertise/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name,YearEmerged")] AreaOfExpertise areaOfExpertise)
        {
            try
            {
                // TODO #17: 
                // <query> Create a new AreaOfExpertise given its properties </query>
                // <input> AreaOfExpertise(Name, YearEmerged) </input>

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AreaOfExpertise/Edit/5
        public ActionResult Edit(string name)
        {
            var areaOfExpertise = new AreaOfExpertise();
            // TODO #18: Duplicate of TODO #16 
            return View();
        }

        // POST: AreaOfExpertise/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string name, [Bind("YearEmerged")] AreaOfExpertise areaOfExpertise)
        {
            try
            {
                // TODO #19: 
                // <query> Edit an old AreaOfExpertise given its name and the new values of its properties </query>
                // <input> name, AreaOfExpertise(AreaOfExpertiseName) </input>

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AreaOfExpertise/Delete/5
        public ActionResult Delete(string name)
        {
            if (name == null)
            {
                return NotFound();
            }

            var areaOfExpertise = new AreaOfExpertise();
            // TODO #20: Duplicate of TODO #16 

            if (areaOfExpertise == null)
            {
                return NotFound();
            }

            return View(areaOfExpertise);
        }

        // POST: AreaOfExpertise/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string name)
        {
            // TODO #21: 
            // <query> Delete an AreaOfExpertise of Name `name`</query>
            // <input> name</input>

            return RedirectToAction(nameof(Index));
        }
    }
}