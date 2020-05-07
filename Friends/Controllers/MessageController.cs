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
        [Route("Message/{username}")]
        public async Task<ActionResult> Index(string username)
        {
            // TODO #22: 
            // <query> Select all messages between two users A having usernameA and B having usernameB (2 cases from A to B and from B to A) </query>
            // <input> usernameA, usernameB </input>
            // <output> List of messages </output>
            if (HomeController.usernameSignedIn != null)
            {
                List<Message> messages = await _messageStore.GetMessages(username, HomeController.usernameSignedIn);

                foreach (var msg in messages)
                {
                    msg.TimeOfSendingDate = new DateTime(msg.TimeOfSending);
                }

                return View(messages);
            }
            return RedirectToAction(nameof(Index), nameof(PersonController));
        }

        // GET: Message/Create
        [HttpGet]
        [Route("Message/Create/{username}")]
        public ActionResult Create(string username)
        {
            return View();
        }

        // POST: Message/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Message/Create/{username}")]
        public async Task<ActionResult> Create(string username, [Bind("ID,Content")] Message message)
        {
            //try
            //{
                if (HomeController.usernameSignedIn != null)
                {
                    message.TimeOfSending = DateTime.Now.Ticks;
                    message.RecieverUsername = username;
                    message.SenderUsername = HomeController.usernameSignedIn;

                    // TODO #23: 
                    // <query> Create a new Message given its properties </query>
                    // <input> Message(ID, SenderUsername, RecieverUsername, TimeOfSending, Content) </input>
                    await _messageStore.CreateMessage(message);
                    return RedirectToAction(nameof(Index), new { username = message.RecieverUsername });
                }
                return RedirectToAction(nameof(Index), nameof(PersonController), new { username = message.RecieverUsername });
            //}
            //catch
            //{
            //    return View();
            //}
        }
    }
}