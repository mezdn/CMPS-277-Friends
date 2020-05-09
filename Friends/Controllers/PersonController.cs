using Friends.Entities;
using Friends.Models;
using Friends.Storage;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Threading.Tasks;

namespace Friends.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonStore _personStore;
        private readonly AreaOfExpertiseStore _areaOfExpertiseStore;

        public static IEnumerable<string> AreasOfExpertise;

        public PersonController(PersonStore personStore, AreaOfExpertiseStore areaOfExpertiseStore)
        {
            _personStore = personStore;
            _areaOfExpertiseStore = areaOfExpertiseStore;
        }

        // GET: Person
        public async Task<ActionResult> Index()
        {
            List<Person> persons = await _personStore.GetPersons();

            foreach (var person in persons)
            {
                person.DateOfBirthDate = new DateTime(person.DateOfBirth);
            }
            return View(persons);
        }

        // GET: Person/Details/5
        public async Task<ActionResult> Details(string username)
        {
            //IsFriendObject has username2 field. Null if person usernameB is not friends with person with usernameA
            IsFriendObject isFriendObject = await _personStore.GetPerson(username, HomeController.usernameSignedIn);
            isFriendObject.Person.DateOfBirthDate = new DateTime(isFriendObject.Person.DateOfBirth);
            return View(isFriendObject);
        }

        // GET: Person/Create
        public async Task<ActionResult> Create()
        {
            AreasOfExpertise = (await _areaOfExpertiseStore.GetAreas()).Select(a => a.Name);
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(string username, [Bind("Username,AreaOfExpertiseName,DisplayName,DateOfBirth,Country,Password")] Person person)
        {
            try
            {
                person.DateOfBirth = person.DateOfBirthDate.Ticks;
                await _personStore.CreatePerson(person);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult> AddFriend(string username)
        {
            await _personStore.AddFriendship(username, HomeController.usernameSignedIn);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> RemoveFriend(string username)
        {
            await _personStore.RemoveFriendship(username, HomeController.usernameSignedIn);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Signin(SigninModel model)
        {
            //0 for invalid login - 1 for valid
            var validLogin = await _personStore.Authenticate(model.Username, model.Password);
            if (validLogin == 1)
            {
                HomeController.usernameSignedIn = model.Username;
            }
            else
            {
                HomeController.usernameSignedIn = null;
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Signout()
        {
            HomeController.usernameSignedIn = null;
            return RedirectToAction(nameof(Index), "");
        }
    }
}