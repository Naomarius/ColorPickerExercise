using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using MvcApplication1.DAL;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        private ColorPickerContext db = new ColorPickerContext();

        public ActionResult Index()
        {
            ViewData["Colors"] = db.Colors.ToList();

            return View(db.Users.ToList());
        }

        [HttpPost]
        public ActionResult AddEdit(User newUser)
        {
            User FoundUser = new User();

            if (newUser.ID != 0)
            { 
                // find the user in db
                FoundUser = db.Users.Where(x => x.ID == newUser.ID).First();
            }

            if (FoundUser.UserName != null)
            {
                FoundUser.UserColor = GetColor(newUser.ColorName);
                FoundUser.ColorName = newUser.ColorName;
                FoundUser.UserName = newUser.UserName;
                db.Entry(FoundUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            else if (!string.IsNullOrEmpty(newUser.UserName))
            {
                newUser.UserColor = GetColor(newUser.ColorName);
                db.Users.Add(newUser);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            ViewData["Colors"] = db.Colors.ToList();
            User userToEdit = GetUser(id);

            // if user was found lets move forward to edit it
            if (userToEdit.ID != -1)
            {
                return View(userToEdit);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            User userToRemove = GetUser(id);

            // if user was found lets remove it
            if (userToRemove.ID != -1)
            {
                db.Users.Remove(userToRemove);
                db.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }

        // finds a user based on id
        private User GetUser(int? id)
        {
            return id.HasValue ? db.Users.Where(x => x.ID == id).First() : new User() { ID = -1 };
        }

        // finds a color based on name
        private Color GetColor(string name)
        {
            return db.Colors.Where(x => x.ColorName.ToLower() == name.ToLower()).First();
        }
    }
}