using CRUDApplication.Models;
using CRUDApplication.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser _user;

        public UserController()
        {
            _user=new UserService();
                
        }
        // GET: User
        public ActionResult GetAllUsers()
        {
            ModelState.Clear();
            return View(_user.GetAllUsers());
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserModel user)
        {
            try
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        if (_user.AddUser(user))
                        {
                            ViewBag.Message = "User added successfully";
                        }
                    }
                    return View();

                }
                catch (Exception)
                {

                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {

            return View(_user.GetAllUsers().Find(user => user.UserId == id));
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserModel user)
        {
            try
            {
                _user.UpdateUser(user);


                return RedirectToAction("GetAllUsers");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                if (_user.DeleteUser(id))
                {
                    ViewBag.Message = "User deleted successfully";
                }

                return RedirectToAction("GetAllUsers");
            }
            catch
            {
                return View();
            }
        }

        
        
    }
}
