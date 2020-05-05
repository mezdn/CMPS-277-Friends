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
            // TODO #34: Done
            // <query> Select all groups</query>
            // <output> List of groups </output>
            
            List<Group> groups = await _groupStore.GetGroups();
            return View(groups);
        }

        // GET: Group/Details/5
        public async Task<ActionResult> Details(int id, string username)
        {
            // TODO #35: Done
            // <query> Select all properties of a Group of ID `id` + a bool `isMember` that indicates whether a member of username `username` is in it or not</query>
            // <input> id </input>
            // <output> Group </output>

            //group has username. Username null if user does not belong to group.
            GroupMemberObject group = await _groupStore.GetGroupAndMember(id, username);

            return View();
        }

        // GET: Group/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Group/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("ID,AdminUsername,Name")] Group group)
        {
            try
            {
                group.DateOfCreation = DateTimeOffset.Now.ToUnixTimeSeconds();
                // TODO #36: Done
                // <query> Create a new Group given its properties </query>
                // <input> Group(ID, AdminUsername, Name, DateOfCreation) </input>

                await _groupStore.CreateGroup(group);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EnterGroup(int id, string username)
        {
            // TODO #41: Done
            // <query>If member with username `username` is not in group of ID `id` add them</query>
            // <input>id, username</input>

            await _groupStore.EnterGroup(id, username);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExitGroup(int id, string username)
        {
            // TODO #42: Done
            // <query>If member with username `username` is in group of ID `id` remove them</query>
            // <input>id, username</input>
            await _groupStore.ExitGroup(id, username);
            return RedirectToAction(nameof(Index));
        }
    }
}