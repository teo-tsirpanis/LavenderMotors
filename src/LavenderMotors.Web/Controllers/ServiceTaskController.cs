#nullable disable
using LavenderMotors.Database.Repository;
using LavenderMotors.Entities;
using LavenderMotors.Web.Models;
using Microsoft.AspNetCore.Mvc;
namespace LavenderMotors.Web.Controllers
{
    public class ServiceTaskController : Controller
    {
        private readonly IEntityRepo<ServiceTask> _serviceTaskRepo;

        public ServiceTaskController(IEntityRepo<ServiceTask> serviceTaskRepo)
        {
            _serviceTaskRepo = serviceTaskRepo;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _serviceTaskRepo.GetAllAsync());
        }
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceTask = await _serviceTaskRepo.GetByIdAsync(id.Value);
            if (serviceTask == null)
            {
                return NotFound();
            }

            var viewModel = new ServiceTaskListViewModel(serviceTask)
            {

            };
            return View(serviceTask);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Description,Hours")] ServiceTaskCreateViewModel serviceTaskCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var newServiceTask = new ServiceTask(serviceTaskCreateViewModel.Code, serviceTaskCreateViewModel.Description, serviceTaskCreateViewModel.Hours);
                await _serviceTaskRepo.AddAsync(newServiceTask);
                return RedirectToAction(nameof(Index));
            }
            return View(serviceTaskCreateViewModel);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceTask = await _serviceTaskRepo.GetByIdAsync(id);
            if (serviceTask == null)
            {
                return NotFound();
            }
            return View(serviceTask);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Code,Description,Hours")] ServiceTaskUpdateViewModel serviceTaskUpdateViewModel)
        {
            if (id != serviceTaskUpdateViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var currentServiceTask = await _serviceTaskRepo.GetByIdAsync(id);
                if (currentServiceTask is null)
                    return BadRequest("Could not find service task.");
                currentServiceTask.Code = serviceTaskUpdateViewModel.Code;
                currentServiceTask.Description = serviceTaskUpdateViewModel.Description;
                currentServiceTask.Hours = serviceTaskUpdateViewModel.Hours;
                await _serviceTaskRepo.UpdateAsync(id, currentServiceTask);
                return RedirectToAction(nameof(Index));
            }
            return View(serviceTaskUpdateViewModel);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var serviceTask = await _serviceTaskRepo.GetByIdAsync(id);
            if (serviceTask == null)
            {
                return NotFound();
            }

            var viewModel = new ServiceTaskDeleteViewModel()
            {
                Code = serviceTask.Code,
                Id = serviceTask.Id,
                Description = serviceTask.Description,
                Hours = serviceTask.Hours,
            };

            return View(viewModel);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var serviceTask = await _serviceTaskRepo.GetByIdAsync(id);
            await _serviceTaskRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
