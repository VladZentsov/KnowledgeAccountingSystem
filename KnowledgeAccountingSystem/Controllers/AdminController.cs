using BLL.Services;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeAccountingSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService _usersService;

        public AdminController(IUserService usersService)
        {
            _usersService = usersService;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        // GET: Users/Create
        //[Authorize(Roles = "Manager")]
        public ActionResult CreateManager()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        //[Authorize(Roles = "Manager")]
        public async Task<ActionResult> CreateManager(User user)
        {
            try
            {
                await _usersService.CreateManagerAsync(user);

                return this.Redirect("/Admin/Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Users/Create
        //[Authorize(Roles = "Manager")]
        public ActionResult CreateAdmin()
        {
            return View();
        }
        // POST: Users/Create
        [HttpPost]
        //[Authorize(Roles = "Manager")]
        public async Task<ActionResult> CreateAdmin(User user)
        {
            try
            {
                await _usersService.CreateAdminAsync(user);

                return this.Redirect("/Admin/Index");
            }
            catch
            {
                return View();
            }
        }
    }
}