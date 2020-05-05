using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Friends.Models;
using Friends.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Friends.Controllers
{
    public class AreaOfExpertiseController : Controller
    {
        private readonly AreaOfExpertiseStore _areaOfExpertiseStore;

        public AreaOfExpertiseController(AreaOfExpertiseStore areaOfExpertiseStore)
        {
            _areaOfExpertiseStore = areaOfExpertiseStore;
        }

        // GET: AreaOfExpertise
        public async Task<ActionResult> Index()
        {
            // TODO #15: Done
            // <query> Select all areas of expertise </query>
            // <output> List of Area of expertise </output>
            
            List<AreaOfExpertise> areas = await _areaOfExpertiseStore.GetAreas();
            return View(areas);
        }

        // GET: AreaOfExpertise/Details/5
        public async Task<ActionResult> Details(string name)
        {
            // TODO #16: Done
            // <query> Select all properties of a AreaOfExpertise of Name `name` </query>
            // <input> name </input>
            // <output> AreaOfExpertise </output>
            AreaOfExpertise areaOfExpertise = await _areaOfExpertiseStore.GetArea(name);

            return View(areaOfExpertise);
        }

        // GET: AreaOfExpertise/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AreaOfExpertise/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Name,YearEmerged")] AreaOfExpertise areaOfExpertise)
        {
            try
            {
                // TODO #17: Done
                // <query> Create a new AreaOfExpertise given its properties </query>
                // <input> AreaOfExpertise(Name, YearEmerged) </input>
                await _areaOfExpertiseStore.CreateArea(areaOfExpertise);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}