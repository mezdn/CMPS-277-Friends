using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Friends.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Friends.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        public ActionResult Index(int postID)
        {
            // TODO #28: 
            // <query> Select all comments on a post with ID `postID`</query>
            // <input> postID </input>
            // <output> List of comments </output>

            return View();
        }

        // GET: Comment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("ID,Content,PersonUsername,PostID")] Comment comment)
        {
            try
            {
                comment.TimeOfCreation = DateTime.Now;

                // TODO #29: 
                // <query> Create a new Comment given its properties </query>
                // <input> Comment(ID, Content, PersonUsername, PostID, TimeOfSending) </input>

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Comment/Edit/5
        public ActionResult Edit(int id, string username)
        {
            // TODO #30: 
            // <query> Select all properties of a Comment of ID `id` IF its owner username = `username`</query>
            // <input> id, username </input>
            // <output> Message </output>

            return View();
        }

        // POST: Comment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string username, [Bind("Content")] Comment comment)
        {
            try
            {
                // TODO #31: 
                // <query> Edit an old Comment given its id and the new values of its properties IF its owner username = `username` </query>
                // <input> id, username, Message(Content) </input>

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Comment/Delete/5
        public ActionResult Delete(int? id, string username)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = new Comment();
            
            // TODO #32 Duplicate of TODO #30

            if (comment == null)
            {
                return NotFound();
            }


            return View(comment);
        }

        // POST: Comment/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO #33: 
                // <query>Delete a Message of ID `id`</query>
                // <input>id</input>

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}