using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Friends.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Friends.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index(int userID)
        {
            // TODO #1: 
            // <query> Select all posts owned by person with ID `userID` </query>
            // <input> id, userID </input>
            // <output> List of Posts </output>

            return View();
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            // TODO #2: 
            // <query> Select all properties for a post of ID `id` </query>
            // <input> id </input>
            // <output> Post </output>
            return View();
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int userID, [Bind("ID,TimeOfCreation,Content,GroupID")] Post post)
        {
            try
            {
                // TODO #3: 
                // <query> Create a new post given its properties </query>
                // <input> post(ID, TimeOfCreation, Content, userID, GroupID) </input>

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            // TODO #4: Duplicate of TODO #2 
            return View();
        }

        // POST: Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, int userID, [Bind("ID,TimeOfCreation,Content,GroupID")] Post post)
        {
            try
            {
                // TODO #5: 
                // <query> Edit an old post given its id and the new vlaues of its properties IF it is owned by a user of ID userID</query>
                // <input> post(ID, TimeOfCreation, Content, GroupID), userID </input>

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id, int userID)
        {
            // TODO #6: 
            // <query> Get a post of ID `id` if its owner has id `userID` </query>
            // <input> id, userID </input>
            // <output> post </output>

            return View();
        }

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO #7: 
                // <query> Delete a post of ID `id`</query>
                // <input> id</input>

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}