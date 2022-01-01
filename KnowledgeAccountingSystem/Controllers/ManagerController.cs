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
    public class ManagerController : Controller
    {
        private readonly IUserService _usersService;
        private readonly IProjectService _projectService;
        private readonly IKnowledgeFormService _knowledgeService;
        private readonly IReportService _reportService;

        public ManagerController(IUserService usersService, IProjectService projectService,IKnowledgeFormService knowledgeFormService, IReportService reportService)
        {
            _usersService = usersService;
            _projectService = projectService;
            _knowledgeService = knowledgeFormService;
            _reportService = reportService;
        }

        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> UsersView()
        {
            return View(await _usersService.GetUsersWithRoleAsync("User"));
        }
        // GET: Users/Create
        //[Authorize(Roles = "Manager")]
        public ActionResult CreateAdmin()
        {
            return View();
        }
        public ActionResult CreateProject()
        {
            return View();
        }
        // POST: Users/Create
        [HttpPost]
        //[Authorize(Roles = "Manager")]
        public async Task<ActionResult> CreateProject(Project project)
        {
            try
            {
                await _projectService.CreateAsync(project);

                return this.Redirect("/Admin/Index");
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> AttachToProject(int id)
        {
            List<Project> projects = (List<Project>)await _projectService.GetAllAsync();
            SelectList SelectProjects = new SelectList(projects, "ProjectId", "ProjectName");
            ViewBag.Projects = projects;
            return View(await _usersService.GetByIdAsync(id));
        }
        // POST: Goods/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AttachToProject(int id, User user)
        {
            try
            {

                user.UserId = id;
                await _usersService.UpdateAsync(user);
                // TODO: Add update logic here

                return RedirectToAction("UsersView");
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> ProjectsView()
        {
            return View(await _projectService.GetAllAsync());
        }
        public async Task<ActionResult> ProjectDetails(int id)
        {
            List<Project> projects = (List<Project>)await _projectService.GetAllAsync();
            SelectList SelectProjects = new SelectList(projects, "ProjectId", "ProjectName");
            ViewBag.Projects = SelectProjects;
            return View(await _usersService.GetByIdAsync(id));
        }

    }
}