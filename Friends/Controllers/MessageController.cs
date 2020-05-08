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
    public class MessageController : Controller
    {
        private readonly MessageStore _messageStore;

        public MessageController(MessageStore messageStore)
        {
            _messageStore = messageStore;
        }

        // GET: Message
        public async Task<ActionResult> Index(string usernameA, string usernameB)
        {
            // TODO #22: 
            // <query> Select all messages between two users A having usernameA and B having usernameB (2 cases from A to B and from B to A) </query>
            // <input> usernameA, usernameB </input>
            // <output> List of messages </output>
            List<Message> messages = await _messageStore.GetMessages(usernameA, usernameB);
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
        public async Task<ActionResult> Create(string senderUsername, [Bind("ID,RecieverUsername,Content")] Message message)
        {
            try
            {
                message.TimeOfSending = DateTimeOffset.Now.ToUnixTimeSeconds();
                message.SenderUsername = senderUsername;

                // TODO #23: 
                // <query> Create a new Message given its properties </query>
                // <input> Message(ID, SenderUsername, RecieverUsername, TimeOfSending, Content) </input>
                await _messageStore.CreateMessage(message);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}