using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Friends.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Friends.Controllers
{
    public class GroupController : Controller
    {
        // GET: Group
        public ActionResult Index()
        {
            // TODO #34: 
            // <query> Select all groups</query>
            // <output> List of groups </output>

            return View();
        }

        // GET: Group/Details/5
        public ActionResult Details(int id, string username)
        {
            // TODO #35: 
            // <query> Select all properties of a Group of ID `id` + a bool `isMember` that indicates whether a member of username `username` is in it or not</query>
            // <input> id </input>
            // <output> Group </output>
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
        public ActionResult Create([Bind("ID,AdminUsername,Name")] Group group)
        {
            try
            {
                group.DateOfCreation = DateTime.Now;
                // TODO #36: 
                // <query> Create a new Group given its properties </query>
                // <input> Group(ID, AdminUsername, Name, DateOfCreation) </input>

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Group/Edit/5
        public ActionResult Edit(int id, string username)
        {
            // TODO #37: 
            // <query> Select all properties of a Group of ID `id` IF its admin username is `username`</query>
            // <input> id, username </input>
            // <output> Group </output>
            return View();
        }

        // POST: Group/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string username, [Bind("Name")] Group group)
        {
            try
            {
                // TODO #38: 
                // <query> Edit an old Group given its id and the new values of its properties IF its amdin username = `username` </query>
                // <input> id, username, Group(Name) </input>

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Group/Delete/5
        public ActionResult Delete(int? id, string username)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = new Group();

            // TODO #39 Duplicate of TODO #37

            if (group == null)
            {
                return NotFound();
            }


            return View(group);
        }

        // POST: Group/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO #40: 
                // <query>Delete a Group of ID `id`</query>
                // <input>id</input>

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EnterGroup(int id, string username)
        {
            // TODO #41: 
            // <query>If member with username `username` is not in group of ID `id` add them</query>
            // <input>id, username</input>

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExitGroup(int id, string username)
        {
            // TODO #42: 
            // <query>If member with username `username` is in group of ID `id` remove them</query>
            // <input>id, username</input>

            return RedirectToAction(nameof(Index));
        }
    }
}