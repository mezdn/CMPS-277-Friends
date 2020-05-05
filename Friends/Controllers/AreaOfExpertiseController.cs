using System.Collections.Generic;
using System.Threading.Tasks;
using Friends.Models;
using Friends.Storage;
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
            List<AreaOfExpertise> areas = await _areaOfExpertiseStore.GetAreas();
            return View(areas);
        }

        // GET: AreaOfExpertise/Details/5
        public async Task<ActionResult> Details(string name)
        {
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