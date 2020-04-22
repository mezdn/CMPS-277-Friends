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
        public ActionResult Index(string username)
        {
            // TODO #1: 
            // <query> Select all posts owned by person with Username `username` </query>
            // <input> id, username </input>
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
        public ActionResult Create(string username, [Bind("ID,TimeOfCreation,CategoryName,Content,GroupID")] Post post)
        {
            try
            {
                // TODO #3: 
                // <query> Create a new post given its properties </query>
                // <input> post(ID, TimeOfCreation, Content, username, GroupID) </input>

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
        public ActionResult Edit(int id, string username, [Bind("ID,TimeOfCreation,CategoryName,Content,GroupID")] Post post)
        {
            try
            {
                // TODO #5: 
                // <query> Edit an old post given its id and the new vlaues of its properties IF it is owned by a user of Username `username` </query>
                // <input> post(ID, TimeOfCreation, Content, GroupID), username </input>

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id, string username)
        {
            // TODO #6: 
            // <query> Get a post of ID `id` if its owner has Username `username` </query>
            // <input> id, username </input>
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

        [HttpPost]
        public ActionResult LikePost(int id, string username)
        {
            // TODO #43: 
            // <query> If user of username `username` didn't like post of ID `id`, add a like </query>
            // <input> id, username </input>

            return View();
        }

        [HttpPost]
        public ActionResult DislikePost(int id, string username)
        {
            // TODO #44: 
            // <query> If user of username `username` likes post of ID `id`, remove the like </query>
            // <input> id, username </input>

            return View();
        }
    }
}