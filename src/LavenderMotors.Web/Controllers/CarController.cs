#nullable disable
using LavenderMotors.Database.Repository;
using LavenderMotors.Entities;
using LavenderMotors.Web.Models;
using Microsoft.AspNetCore.Mvc;
namespace LavenderMotors.Web.Controllers
{
    public class CarController : Controller
    {
        private readonly IEntityRepo<Car> _carRepo;

        public CarController(IEntityRepo<Car> carRepo)
        {
            _carRepo = carRepo;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _carRepo.GetAllAsync());
        }
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _carRepo.GetByIdAsync(id.Value);
            if (car == null)
            {
                return NotFound();
            }

            var viewModel = new CarListViewModel(car)
            {

            };
            return View(car);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,Model,CarRegistrationNumber")] CarCreateViewModel carCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var newCar = new Car(carCreateViewModel.Brand, carCreateViewModel.Model, carCreateViewModel.CarRegistrationNumber);
                await _carRepo.AddAsync(newCar);
                return RedirectToAction(nameof(Index));
            }
            return View(carCreateViewModel);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _carRepo.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Brand,Model,CarRegistrationNumber")] CarUpdateViewModel carUpdateViewModel)
        {
            if (id != carUpdateViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var currentCar = await _carRepo.GetByIdAsync(id);
                if (currentCar is null)
                    return BadRequest("Could not find car.");
                currentCar.Brand = carUpdateViewModel.Brand;
                currentCar.Model = carUpdateViewModel.Model;
                currentCar.CarRegistrationNumber = carUpdateViewModel.CarRegistrationNumber;
                await _carRepo.UpdateAsync(id, currentCar);
                return RedirectToAction(nameof(Index));
            }
            return View(carUpdateViewModel);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carRepo.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            var viewModel = new CarDeleteViewModel()
            {
                Brand = car.Brand,
                Id = car.Id,
                Model = car.Model,
                CarRegistrationNumber = car.CarRegistrationNumber,
            };

            return View(viewModel);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var car = await _carRepo.GetByIdAsync(id);
            await _carRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
