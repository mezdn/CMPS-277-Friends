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
    public class PostController : Controller
    {
        private readonly PostStore _postStore;

        public PostController(PostStore postStore)
        {
            _postStore = postStore;
        }

        // GET: Post
        public async Task<ActionResult> Index(string username)
        {
            // TODO #1: Done
            // <query> Select all posts owned by person with Username `username` </query>
            // <input> id, username </input>
            // <output> List of Posts </output>
            List<Post> posts = await _postStore.GetPosts(username);
            return View(posts);
        }

        // GET: Post/Details/5
        public async Task<ActionResult> Details(int id)
        {
            // TODO #2: Done
            // <query> Select all properties for a post of ID `id` </query>
            // <input> id </input>
            // <output> Post </output>

            Post post = await _postStore.GetPost(id);
            return View(post);
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(string username, [Bind("ID,CategoryName,Content,GroupID")] Post post)
        {
            try
            {
                post.TimeOfCreation = DateTimeOffset.Now.ToUnixTimeSeconds();

                // TODO #3: Done
                // <query> Create a new post given its properties </query>
                // <input> post(ID, TimeOfCreation, Content, username, GroupID) </input>
                await _postStore.CreatePost(post);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            // TODO #4: Duplicate of TODO #2 Done
            Post post = await _postStore.GetPost(id);
            return View(post);
        }

        // POST: Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, string username, [Bind("CategoryName,Content")] Post post)
        {
            try
            {
                // TODO #5: Done
                // <query> Edit an old post given its id and the new vlaues of its properties IF it is owned by a user of Username `username` </query>
                // <input> post(CategoryName, Content), username </input>

                await _postStore.UpdatePost(post, username);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        public async Task<ActionResult> Delete(int id, string username)
        {
            // TODO #6: Done
            // <query> Get a post of ID `id` if its owner has Username `username` </query>
            // <input> id, username </input>
            // <output> post </output>

            Post post = await _postStore.GetPostVerify(id, username);
            return View(post);
        }

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                // TODO #7: Done
                // <query> Delete a post of ID `id`</query>
                // <input> id</input>

                await _postStore.DeletePost(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> LikePost(int id, string username)
        {
            // TODO #43: Done
            // <query> If user of username `username` didn't like post of ID `id`, add a like </query>
            // <input> id, username </input>
            await _postStore.LikePost(id, username);
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> DislikePost(int id, string username)
        {
            // TODO #44: Done
            // <query> If user of username `username` likes post of ID `id`, remove the like </query>
            // <input> id, username </input>

            await _postStore.LikePost(id, username);
            return View();
        }
    }
}