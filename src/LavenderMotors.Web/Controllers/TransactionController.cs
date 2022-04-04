#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LavenderMotors.Database;
using LavenderMotors.Entities;
using LavenderMotors.Web.Models;

namespace LavenderMotors.Web.Controllers;

public class TransactionController : Controller
{
    private readonly GarageContext _context;

    public TransactionController(GarageContext context)
    {
        _context = context;
    }

    // GET: Transaction
    public async Task<IActionResult> Index()
    {
        var garageContext =
            _context.Transactions
                .Include(t => t.Car)
                .Include(t => t.Customer)
                .Include(t => t.Manager)
                .Select(x => new TransactionSummaryViewModel(x));
        return View(await garageContext.ToListAsync());
    }

    // GET: Transaction/Details/5
    public async Task<IActionResult> Details(Guid id)
    {
        var transaction = await _context.Transactions
            .Include(t => t.Car)
            .Include(t => t.Customer)
            .Include(t => t.Manager)
            .Include(t => t.Lines)
            .ThenInclude(t => t.Engineer)
            .Include(t => t.Lines)
            .ThenInclude(t => t.ServiceTask)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (transaction == null)
        {
            return NotFound();
        }

        return View(transaction);
    }

    // GET: Transaction/Create
    public IActionResult Create()
    {
        ViewData["CarId"] = new SelectList(_context.Cars, nameof(Car.Id), nameof(Car.CarRegistrationNumber));
        ViewData["CustomerId"] = new SelectList(_context.Customers, nameof(Customer.Id), nameof(Customer.Name));
        ViewData["ManagerId"] = new SelectList(_context.Managers, nameof(Manager.Id), nameof(Manager.Name));
        return View();
    }

    // POST: Transaction/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TransactionCreateViewModel tcvm)
    {
        if (ModelState.IsValid)
        {
            var car = await _context.Cars.FindAsync(tcvm.CarId);
            var customer = await _context.Customers.FindAsync(tcvm.CustomerId);
            var manager = await _context.Managers.FindAsync(tcvm.ManagerId);
            if (car is null || customer is null || manager is null)
            {
                return BadRequest("Car, customer or manager not found");
            }

            var transaction = new Transaction
            {
                Car = car,
                Customer = customer,
                Manager = manager,
                Date = tcvm.Date
            };
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["CarId"] = new SelectList(_context.Cars, "Id", nameof(Car.CarRegistrationNumber), tcvm.CarId);
        ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name", tcvm.CustomerId);
        ViewData["ManagerId"] = new SelectList(_context.Managers, "Id", "EmployeeType", tcvm.ManagerId);
        return View(tcvm);
    }

    // GET: Transaction/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var transaction = await _context.Transactions
            .Include(t => t.Car)
            .Include(t => t.Customer)
            .Include(t => t.Manager)
            .Include(t => t.Lines)
            .ThenInclude(t => t.Engineer)
            .Include(t => t.Lines)
            .ThenInclude(t => t.ServiceTask)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (transaction == null)
        {
            return NotFound();
        }
        ViewData["CarId"] = new SelectList(_context.Cars, "Id", nameof(Car.CarRegistrationNumber), transaction.CarId);
        ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name", transaction.CustomerId);
        ViewData["ManagerId"] = new SelectList(_context.Managers, "Id", "Name", transaction.ManagerId);
        var tevm = new TransactionEditViewModel(transaction);
        return View(tevm);
    }

    // POST: Transaction/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, TransactionEditViewModel tevm)
    {
        var transaction = await _context.Transactions
            .Include(t => t.Car)
            .Include(t => t.Customer)
            .Include(t => t.Manager)
            .Include(t => t.Lines)
            .ThenInclude(t => t.Engineer)
            .Include(t => t.Lines)
            .ThenInclude(t => t.ServiceTask)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (transaction is null)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                transaction.Date = tevm.Date;
                transaction.CarId = tevm.CarId;
                transaction.CustomerId = tevm.CustomerId;
                transaction.ManagerId = tevm.ManagerId;
                _context.Update(transaction);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TransactionExistsAsync(tevm.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Brand", transaction.CarId);
        ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name", transaction.CustomerId);
        ViewData["ManagerId"] = new SelectList(_context.Managers, "Id", "EmployeeType", transaction.ManagerId);
        return View(transaction);
    }

    private Task<bool> TransactionExistsAsync(Guid id)
    {
        return _context.Transactions.AnyAsync(e => e.Id == id);
    }
}
