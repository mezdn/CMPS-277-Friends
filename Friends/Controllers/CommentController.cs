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
        [HttpGet]
        [Route("Comment/{postID}")]
        public async Task<ActionResult> Index(int postID)
        {
            List<Comment> comments = await _commentStore.GetComments(postID);

            foreach (var comment in comments)
            {
                comment.TimeOfCreationDate = new DateTime(comment.TimeOfCreation);
            }

            return View(comments);
        }

        // GET: Comment/Create
        [HttpGet]
        [Route("Comment/Create/{postID}")]
        public ActionResult Create(int postID)
        {
            if (HomeController.usernameSignedIn == null)
            {
                RedirectToAction(nameof(SignIn), nameof(PersonController));
            }  
            return View();
        }

        // POST: Comment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Comment/Create/{postID}")]
        public async Task<ActionResult> Create(int postID, [Bind("ID,Content")] Comment comment)
        {
            if (HomeController.usernameSignedIn == null)
            {
                RedirectToAction(nameof(SignIn), nameof(PersonController));
            }
            try
            {
                comment.TimeOfCreation = DateTime.Now.Ticks;
                comment.PostID = postID;
                comment.PersonUsername = HomeController.usernameSignedIn;

                await _commentStore.CreateComment(comment);

                return RedirectToAction(nameof(Index), new { postID = postID });
            }
            catch
            {
                return View();
            }
        }
    }
}