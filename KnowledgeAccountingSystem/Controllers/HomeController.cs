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
    public class HomeController : Controller
    {
        private readonly IUserService _usersService;

        public HomeController(IUserService usersService)
        {
            _usersService = usersService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }

            return Redirect("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginInfo loginInfo)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("Login");
            }
            var u = _usersService.GetAllAsync();
            List<User> users = new List<User>(await u);
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            var user = manager.Find(loginInfo.Username, loginInfo.Password);

            var userIdentity = manager.CreateIdentity(user,
                DefaultAuthenticationTypes.ApplicationCookie);

            authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);

            return Redirect("Index");
        }
        // GET: Users/Create
        //[Authorize(Roles = "Manager")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        //[Authorize(Roles = "Manager")]
        public async Task<ActionResult> Create(User user)
        {
            try
            {
                await _usersService.CreateUserAsync(user);

                return this.Redirect("/Users/Index");
            }
            catch
            {
                return View();
            }
        }
    }
}