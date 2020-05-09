using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Friends.Models;
using Friends.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Friends.Controllers
{
    public class GroupController : Controller
    {
        private readonly GroupStore _groupStore;

        public GroupController(GroupStore groupStore)
        {
            _groupStore = groupStore;
        }

        // GET: Group
        public async Task<ActionResult> Index()
        {
            List<Group> groups = await _groupStore.GetGroups();

            foreach (var grp in groups)
            {
                grp.DateOfCreationDate = new DateTime(grp.DateOfCreation);
            }

            return View(groups);
        }

        // GET: Group/Details/5
        public async Task<ActionResult> Details(int id)
        {
            //group has username. Username null if user does not belong to group.
            GroupMemberObject group = await _groupStore.GetGroupAndMember(id, HomeController.usernameSignedIn);

            return View(group);
        }

        // GET: Group/Create
        public ActionResult Create()
        {
            if (HomeController.usernameSignedIn == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // POST: Group/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("ID,Name")] Group group)
        {
            if (HomeController.usernameSignedIn == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                group.DateOfCreation = DateTime.Now.Ticks;
                group.AdminUsername = HomeController.usernameSignedIn;

                await _groupStore.CreateGroup(group);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult> EnterGroup(int id)
        {
            await _groupStore.EnterGroup(id, HomeController.usernameSignedIn);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> ExitGroup(int id)
        {
            await _groupStore.ExitGroup(id, HomeController.usernameSignedIn);
            return RedirectToAction(nameof(Index));
        }
    }
}