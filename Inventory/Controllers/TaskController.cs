using Microsoft.AspNetCore.Mvc;
using Project.BL.Service.ISevice;

namespace Inventory.Controllers
{
    public class TaskKController : Controller
    {
        private readonly ITaskService _TaskItemService;
        private readonly IProjectService _projectService;


        public TaskKController(ITaskService TaskItemService, IProjectService projectService)
        {
            _TaskItemService = TaskItemService;
            _projectService = projectService;
        }
        public async Task<IActionResult> Index()
        {
            var TaskItems = await _TaskItemService.GetAllTasksAsync();
            return View(TaskItems);
        }
        public async Task<IActionResult> Details(int id)
        {
            var TaskItem = await _TaskItemService.GetTasksByProjectIdAsync(id);
            if (TaskItem == null)
            {
                return NotFound();
            }

            return View(TaskItem);
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Project.MODELS.Entities.Task TaskItem)
        {
            if (ModelState.IsValid)
            {
                await _TaskItemService.CreateTaskAsync(TaskItem);
                return RedirectToAction(nameof(Index));
            }
            return View(TaskItem);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var TaskItem = await _TaskItemService.GetTaskByIdAsync(id);
            if (TaskItem == null)
            {
                return NotFound();
            }
            return View(TaskItem);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Project.MODELS.Entities.Task TaskItem)
        {
            if (id != id) return NotFound();

            if (ModelState.IsValid)
            {
                await _TaskItemService.UpdateTaskAsync(TaskItem);
                return RedirectToAction(nameof(Index));
            }
            return View(TaskItem);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var TaskItem = await _TaskItemService.GetTaskByIdAsync(id);
            if (TaskItem == null) return NotFound();
            return View(TaskItem);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTaskItem(int id)
        {
            await _TaskItemService.DeleteTaskAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
