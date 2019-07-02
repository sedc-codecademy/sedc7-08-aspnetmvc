using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.DataLayer.Contracts;
using todoModels = ToDo.DataLayer.Entities;

namespace ToDo.WebApp.Controllers
{
    public class TasksDbController : Controller
    {
        private readonly ITaskRepository _taskRepository;

        public TasksDbController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        // GET: TasksDb
        public async Task<IActionResult> Index()
        {
            return View(await _taskRepository.GetAllAsync());
        }

        // GET: TasksDb/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var task = await _taskRepository.GetByIdAsync(id.Value);
            if (task == null)
                return NotFound();

            return View(task);
        }

        // GET: TasksDb/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TasksDb/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Priority,Type,Id,Title,Description,Status")] todoModels.Task task)
        {
            if (ModelState.IsValid)
            {
                await _taskRepository.AddAsync(task);
                return RedirectToAction(nameof(Index));
            }

            return View(task);
        }

        // GET: TasksDb/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var task = await _taskRepository.GetByIdAsync(id.Value);
            if (task == null)
                return NotFound();

            return View(task);
        }

        // POST: TasksDb/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Priority,Type,Id,Title,Description,Status")] todoModels.Task task)
        {
            if (id != task.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                bool updated = await _taskRepository.UpdateAsync(task);
                if (updated)
                    return RedirectToAction(nameof(Index));
            }

            return View(task);
        }

        // GET: TasksDb/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var task = await _taskRepository.GetByIdAsync(id.Value);
            if (task == null)
                return NotFound();

            return View(task);
        }

        // POST: TasksDb/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            await _taskRepository.RemoveAsync(task);

            return RedirectToAction(nameof(Index));
        }
    }
}
