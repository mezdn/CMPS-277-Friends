using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Friends.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Friends.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Index(string usernameA, string usernameB)
        {
            // TODO #22: 
            // <query> Select all messages between two users A having usernameA and B having usernameB (2 cases from A to B and from B to A) </query>
            // <input> usernameA, usernameB </input>
            // <output> List of messages </output>

            return View();
        }

        // GET: Message/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Message/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("ID,SenderUsername,RecieverUsername,Content")] Message message)
        {
            try
            {
                message.TimeOfSending = DateTime.Now;

                // TODO #23: 
                // <query> Create a new Message given its properties </query>
                // <input> Message(ID, SenderUsername, RecieverUsername, TimeOfSending, Content) </input>

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Message/Edit/5
        public ActionResult Edit(int id, string username)
        {
            // TODO #24: 
            // <query> Select all properties of a Message of ID `id` IF its sender username = `username` </query>
            // <input> id, username </input>
            // <output> Message </output>

            return View();
        }

        // POST: Message/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string username, [Bind("Content")] Message message)
        {
            try
            {
                // TODO #25: 
                // <query> Edit an old Message given its id and the new values of its properties IF its sender username = `username` </query>
                // <input> id, username, Message(Content) </input>

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Message/Delete/5
        public ActionResult Delete(int? id, string username)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = new Message();

            if (message == null)
            {
                return NotFound();
            }

            // TODO #26 Duplicate of TODO #25

            return View(message);
        }

        // POST: Message/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            // TODO #27: 
            // <query>Delete a Message of ID `id`</query>
            // <input>id</input>

            return RedirectToAction(nameof(Index));
        }
    }
}