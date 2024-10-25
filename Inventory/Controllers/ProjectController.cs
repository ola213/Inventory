using Microsoft.AspNetCore.Mvc;
using Project.BL.Service.ISevice;

namespace Inventory.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<IActionResult> Index()
        {
            var projects = await _projectService.GetAllProjectsAsync();
            return View(projects);
        }

        public async Task<IActionResult> Details(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        public async Task<IActionResult> Create(Project.MODELS.Entities.Project project)
        {
            if (ModelState.IsValid)
            {
                await _projectService.CreateProjectAsync(project);
                return RedirectToAction(nameof(Index));
            }

            return View(project);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _projectService.DeleteProjectAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _projectService.GetProjectByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(int id, Project.MODELS.Entities.Project project)
        {
            if (id != project.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _projectService.UpdateProjectAsync(project);
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }
    }
}
