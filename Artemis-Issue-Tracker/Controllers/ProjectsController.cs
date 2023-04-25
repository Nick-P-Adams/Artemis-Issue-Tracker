using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Artemis_Issue_Tracker.Data;
using Artemis_Issue_Tracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Data;
using X.PagedList;

namespace Artemis_Issue_Tracker.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<IdentityUser> _userManager;

        public ProjectsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Projects
        // This is where we need to filter the list of projects based on the UserProject table
        [Authorize]
        public async Task<IActionResult> Index(string sortOrder, string searchTerm, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["TitleSort"] = sortOrder == "title_ascend" ? "title_descend" : "title_ascend";
            ViewData["DateSort"] = String.IsNullOrEmpty(sortOrder) ? "date_descend" : "";

            var currentUserId = _userManager.GetUserId(User);
            var projects = from p in _context.Project
                           join up in _context.UserProject
                           on p.Id equals up.ProjectId
                           where up.UserId == currentUserId
                           select p;

            if (!String.IsNullOrEmpty(searchTerm))
            {
                projects = projects.Where(p => p.Title.Contains(searchTerm));
            }

            switch (sortOrder)
            {
                case "title_ascend":
                    projects = projects.OrderBy(p => p.Title);
                    break;
                case "title_descend":
                    projects = projects.OrderByDescending(p => p.Title);
                    break;
                case "date_descend":
                    projects = projects.OrderByDescending(p => p.CreationDate);
                    break;
                default:
                    projects = projects.OrderBy(p => p.CreationDate);
                    break;
            }

            int pageNumber = page ?? 1,
                pageSize = 8;

            // The ProjectIndexViewModel at the moment is not neccessary atm
            // However, it may be useful in the future if I need to pass more than just the Project model info to the view
            var projectsViewModel = new ProjectIndexViewModel
            {
                Projects = await projects.ToPagedListAsync(pageNumber, pageSize)
            };
            
            return View(projectsViewModel.Projects);
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Project == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        // responsible for giving us the project create view
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        // Once on the view this handles the routes that come next
        // Need to add the project id and user id to the UserProject table here 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Summary,CreationDate")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Project.Add(project);
                await _context.SaveChangesAsync();

                var currentUserId = _userManager.GetUserId(User);
                var userProject = new UserProject() { UserId = currentUserId, ProjectId = project.Id };

                _context.UserProject.Add(userProject);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Project == null)
            {
                return NotFound();
            }

            var project = await _context.Project.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Summary,CreationDate")] Project project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        _context.Update(project);

                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();

                        return RedirectToAction(nameof(Index));
                    }
                    catch (DBConcurrencyException ex) 
                    {
                        await transaction.RollbackAsync();
                        return StatusCode(500, $"An error occurred while updating the project: {ex.Message}");
                    }
                }
            }
            return View(project);
        }
        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Project == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .FirstOrDefaultAsync(m => m.Id == id);

            if (project == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var currentUserId = _userManager.GetUserId(User);

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var project = await _context.Project.FindAsync(id);

                    if (project == null)
                    {
                        return NotFound();
                    }

                    var userProject = await _context.UserProject
                                            .Where(up => up.ProjectId == project.Id && up.UserId == currentUserId)
                                            .SingleAsync();

                    if (userProject == null)
                    {
                        return NotFound();
                    }

                    _context.UserProject.Remove(userProject);
                    _context.Project.Remove(project);

                    // Save changes in a transaction
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DBConcurrencyException ex)
                {
                    // If an error occurs, roll back the transaction
                    await transaction.RollbackAsync();
                    return StatusCode(500, $"An error occurred while deleting the project: {ex.Message}");
                }
            }
        }

        private bool ProjectExists(int id)
        {
          return _context.Project.Any(e => e.Id == id);
        }
    }
}
