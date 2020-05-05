using Friends.Models;
using Friends.Storage;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg;
using SQLitePCL;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Threading.Tasks;

namespace Friends.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonStore _personStore;

        public PersonController(PersonStore personStore)
        {
            _personStore = personStore;
        }

        // GET: Person
        public async Task<ActionResult> Index()
        {
            // TODO #45: Done
            // <query> Select all persons</query>
            // <output> List of Persons </output>
            List<Person> persons = await _personStore.GetPersons();
            return View(persons);
        }

        // GET: Person/Details/5
        public async Task<ActionResult> Details(string usernameA, string usernameB)
        {
            // TODO #46: Done
            // <query> Select all properties for a Person of username `usernameA` + add a bool isFreind that indicates whether person with username `usernameB` is friend with them or not</query>
            // <input> usernameA, usernameB </input>
            // <output> Person </output>

            //IsFriendObject has username2 field. Null if person usernameB is not friends with person with usernameA
            IsFriendObject isFriendObject = await _personStore.GetPerson(usernameA, usernameB);
            return View();
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(string username, [Bind("Username,AreaOfExpertiseName,DisplayName,DateOfBirth,Country,Password")] Person person)
        {
            try
            {
                // TODO #47: Done
                // <query> Create a new person given its properties </query>
                // <input> Person(Username, AreaOfExpertiseName, DisplayName, DateOfBirth, Country, Password) </input>
                await _personStore.CreatePerson(person);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddFriend(string usernameA, string usernameB)
        {
            // TODO #52: Done
            // <query> If Persons of usernames `usernameA` and `usernameB` are not friends, make them friends</query>
            // <input> usernameA, usernameB </input>
            await _personStore.AddFriendship(usernameA, usernameB);
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> RemoveFriend(string usernameA, string usernameB)
        {
            // TODO #52: Done
            // <query> If Persons of usernames `usernameA` and `usernameB` are friends, remove their friendship</query>
            // <input> usernameA, usernameB </input>
            await _personStore.RemoveFriendship(usernameA, usernameB);
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Signin(string username, string password)
        {
            // TODO #54: Done
            // <query> login person of username `username` and password `password`</query>
            // <input> username, password </input>
            // <output> any result that indicates the sucess/failure of the process </output>

            //0 for invalid login - 1 for valid
            int validLogin = await _personStore.Authenticate(username, password);
            return View();
        }

        [HttpPost]
        public ActionResult Signout(string username)
        {
            // TODO for Mohammed 
            return View();
        }
    }
}