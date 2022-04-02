#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LavenderMotors.Database;
using LavenderMotors.Entities;
using LavenderMotors.Database.Repository;
using LavenderMotors.Web.Models;

namespace LavenderMotors.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IEntityRepo<Customer> _customerRepo;

        public CustomerController(IEntityRepo<Customer> customerRepo)
        {
            _customerRepo = customerRepo;
        }

        // GET: Customer
        public async Task<IActionResult> Index()
        {
            return View(await _customerRepo.GetAllAsync());
        }

        // GET: Customer/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerRepo.GetByIdAsync(id.Value);
            if (customer == null)
            {
                return NotFound();
            }

            var viewModel = new CustomerListViewModel(customer)
            {
                
            };

            //foreach (var comment in todo.Comments)
            //{
            //    var commentViewModel = new TodoCommentListViewModel
            //    {
            //        Text = comment.Text
            //    };
            //    viewModel.Comments.Add(commentViewModel);
            //}

            return View(customer);
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Phone,TIN")] CustomerCreateViewModel customerCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var newCustomer = new Customer(customerCreateViewModel.Name,customerCreateViewModel.Surname,customerCreateViewModel.Phone,customerCreateViewModel.TIN);
                await _customerRepo.AddAsync(newCustomer);
                return RedirectToAction(nameof(Index));
            }
            return View(customerCreateViewModel);
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerRepo.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Surname,Phone,TIN")] CustomerUpdateViewModel customerUpdateViewModel)
        {
            if (id != customerUpdateViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var currentCustomer = await _customerRepo.GetByIdAsync(id);
                if (currentCustomer is null)
                    return BadRequest("Could not find customer");
                currentCustomer.Name = customerUpdateViewModel.Name;
                currentCustomer.Surname = customerUpdateViewModel.Surname;
                currentCustomer.TIN = customerUpdateViewModel.TIN;
                currentCustomer.Phone = customerUpdateViewModel.Phone;
                await _customerRepo.UpdateAsync(id, currentCustomer);
                return RedirectToAction(nameof(Index));
            }
            return View(customerUpdateViewModel);
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var customer = await _customerRepo.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            var viewModel = new CustomerDeleteViewModel()
            {
                Name = customer.Name,
                Id = customer.Id,
                Surname = customer.Surname,
                TIN = customer.TIN,
                Phone = customer.Phone,
            };

            return View(viewModel);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var customer = await _customerRepo.GetByIdAsync(id);
            await _customerRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
