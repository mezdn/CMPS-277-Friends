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
        private readonly CategoriesStore _categoriesStore;
        private readonly GroupStore _groupStore;

        public static IEnumerable<string> CategoryNames;
        public static IEnumerable<string> GroupNames;
        public static List<Group> Groups;

        public PostController(PostStore postStore, CategoriesStore categoriesStore, GroupStore groupStore)
        {
            _postStore = postStore;
            _categoriesStore = categoriesStore;
            _groupStore = groupStore;
        }

        // GET: Post
        public async Task<ActionResult> Index(string username)
        {
            List<Post> posts = await _postStore.GetPosts(username);
            CategoryNames = (await _categoriesStore.GetCategories()).Select(c => c.Name);
            Groups = await _groupStore.GetGroups();
            GroupNames = Groups.Select(g => g.Name);

            foreach (var post in posts)
            {
                post.TimeOfCreationDate = new DateTime(post.TimeOfCreation);
                var group = Groups.FirstOrDefault(g => g.ID == post.GroupID);
                if (group != null)
                {
                    post.Group = group.Name;
                }
            }
            return View(posts);
        }

        // GET: Post/Details/5
        public async Task<ActionResult> Details(int id)
        {
            CategoryNames = (await _categoriesStore.GetCategories()).Select(c => c.Name);
            Groups = await _groupStore.GetGroups();
            GroupNames = Groups.Select(g => g.Name);

            var postObject = await _postStore.GetPostAndLike(id, HomeController.usernameSignedIn);
            postObject.Post.TimeOfCreationDate = new DateTime(postObject.Post.TimeOfCreation);
            var group = Groups.FirstOrDefault(g => g.ID == postObject.Post.GroupID);
            if (group != null)
            {
                postObject.Post.Group = group.Name;
            }
            return View(postObject);
        }

        // GET: Post/Create
        public async Task<ActionResult> Create()
        {
            if (HomeController.usernameSignedIn == null)
            {
                return RedirectToAction(nameof(SignIn), nameof(Person));
            }
            var groups = await _groupStore.GetGroups();
            Groups = new List<Group>();

            foreach (var grp in groups)
            {
                var groupAndMember = await _groupStore.GetGroupAndMember(grp.ID, HomeController.usernameSignedIn);
                if (groupAndMember.isMember)
                {
                    Groups.Add(grp);
                }
            }

            GroupNames = Groups.Select(g => g.Name);
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("ID,CategoryName,Content,Group")] Post post)
        {
            try
            {
                post.TimeOfCreation = DateTime.Now.Ticks;
                post.PersonUsername = HomeController.usernameSignedIn;

                if (post.Group != "None")
                {
                    var group = Groups.FirstOrDefault(g => g.Name == post.Group);
                    if (group != null)
                    {
                        post.GroupID = group.ID;
                    }
                }

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
            if (HomeController.usernameSignedIn == null)
            {
                return RedirectToAction(nameof(SignIn), nameof(Person));
            }
            CategoryNames = (await _categoriesStore.GetCategories()).Select(c => c.Name);
            var groups = await _groupStore.GetGroups();
            Groups = new List<Group>();
            GroupNames = Groups.Select(g => g.Name);

            var post = await _postStore.GetPost(id);
            post.TimeOfCreationDate = new DateTime(post.TimeOfCreation);

            var group = Groups.FirstOrDefault(g => g.ID == post.GroupID);
            if (group != null)
            {
                post.Group = group.Name;

            }
            return View(post);
        }

        // POST: Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("CategoryName,Content")] Post post)
        {
            try
            {
                post.ID = id;
                await _postStore.UpdatePost(post, HomeController.usernameSignedIn);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (HomeController.usernameSignedIn == null)
            {
                return RedirectToAction(nameof(SignIn), nameof(Person));
            }

            CategoryNames = (await _categoriesStore.GetCategories()).Select(c => c.Name);
            Groups = await _groupStore.GetGroups();
            GroupNames = Groups.Select(g => g.Name);

            //Returns null if id doesn't exist or if username does not match
            Post post = await _postStore.GetPostVerify(id, HomeController.usernameSignedIn);
            post.TimeOfCreationDate = new DateTime(post.TimeOfCreation);
            post.Group = Groups.FirstOrDefault(g => g.ID == post.GroupID).Name;
            return View(post);
        }

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            if (HomeController.usernameSignedIn == null)
            {
                return RedirectToAction(nameof(SignIn), nameof(Person));
            }

            try
            {
                await _postStore.DeletePost(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult> LikePost(int id)
        {
            await _postStore.LikePost(id, HomeController.usernameSignedIn);
            return RedirectToAction(nameof(Details), new { id = id });
        }

        [HttpGet]
        public async Task<ActionResult> DislikePost(int id)
        {
            await _postStore.UnlikePost(id, HomeController.usernameSignedIn);
            return RedirectToAction(nameof(Details), new { id = id });
        }
    }
}