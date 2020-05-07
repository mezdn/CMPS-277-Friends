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
    public class CommentController : Controller
    {
        private readonly CommentStore _commentStore;

        public CommentController(CommentStore commentStore)
        {
            _commentStore = commentStore;
        }

        // GET: Comment
        public async Task<ActionResult> Index(int postID)
        {
            // TODO #28: Done
            // <query> Select all comments on a post with ID `postID`</query>
            // <input> postID </input>
            // <output> List of comments </output>
            List<Comment> comments = await _commentStore.GetComments(postID);
            return View(comments);
        }

        // GET: Comment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(int postID, string personUsername, [Bind("ID,Content")] Comment comment)
        {
            try
            {
                comment.TimeOfCreation = DateTimeOffset.Now.ToUnixTimeSeconds();
                comment.PostID = postID;
                comment.PersonUsername = personUsername;

                // TODO #29: Done
                // <query> Create a new Comment given its properties </query>
                // <input> Comment(ID, Content, PersonUsername, PostID, TimeOfSending) </input>

                await _commentStore.CreateComment(comment);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}