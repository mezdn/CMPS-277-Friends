using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Friends.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Friends.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            // TODO #45: 
            // <query> Select all persons</query>
            // <output> List of Persons </output>
            return View();
        }

        // GET: Person/Details/5
        public ActionResult Details(string usernameA, string usernameB)
        {
            // TODO #46: 
            // <query> Select all properties for a Person of username `usernameA` + add a bool isFreind that indicates whether person with username `usernameB` is friend with them or not</query>
            // <input> usernameA, usernameB </input>
            // <output> Person </output>
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
        public ActionResult Create(string username, [Bind("Username,AreaOfExpertiseName,DisplayName,DateOfBirth,Country,Password")] Person person)
        {
            try
            {
                // TODO #47: 
                // <query> Create a new person given its properties </query>
                // <input> Person(Username, AreaOfExpertiseName, DisplayName, DateOfBirth, Country, Password) </input>

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(string username)
        {
            // TODO #48: 
            // <query> Select all properties for a Person of username `username`</query>
            // <input> username </input>
            // <output> Person </output>
            return View();
        }

        // POST: Person/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string username, [Bind("AreaOfExpertiseName,DisplayName,DateOfBirth,Country,Password")] Person person)
        {
            try
            {
                // TODO #49: 
                // <query> Edit an old Person given their username `username` and the new vlaues of its properties</query>
                // <input> Person(AreaOfExpertiseName,DisplayName,DateOfBirth,Country,Password,username) </input>

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(string username)
        {
            // TODO #50: Duplicate of TODO #48 
            return View();
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string username)
        {
            try
            {
                // TODO #51: 
                // <query> Delete a Person of Username `username`</query>
                // <input> id</input>

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddFriend(string usernameA, string usernameB)
        {
            // TODO #52: 
            // <query> If Persons of usernames `usernameA` and `usernameB` are not friends, make them friends</query>
            // <input> usernameA, usernameB </input>
            return View();
        }

        [HttpPost]
        public ActionResult RemoveFriend(string usernameA, string usernameB)
        {
            // TODO #52: 
            // <query> If Persons of usernames `usernameA` and `usernameB` are friends, remove their friendship</query>
            // <input> usernameA, usernameB </input>
            return View();
        }

        [HttpPost]
        public ActionResult Signin(string username, string password)
        {
            // TODO #54: 
            // <query> login person of username `username` and password `password`</query>
            // <input> username, password </input>
            // <output> any result that indicates the sucess/failure of the process </output>
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