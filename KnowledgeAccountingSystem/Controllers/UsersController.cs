using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using DAL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace KnowledgeAccountingSystem.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _usersService;

        public UsersController(IUserService usersService)
        {
            _usersService = usersService;
        }

        // GET: Users
        public async Task<ActionResult> Index()
        {
            return View(await _usersService.GetAllAsync());
        }

        // GET: Users/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _usersService.GetByIdAsync(id));
        }


        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       

        [HttpGet]
        public ActionResult SignOut()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();

            return Redirect("Index");
        }
    }
}