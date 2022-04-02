using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LavenderMotors.Entities;
using Microsoft.EntityFrameworkCore;

namespace LavenderMotors.Database.Repository;

internal class EmployeeRepo : IEntityRepo<Employee>
{
    private readonly GarageContext _context;

    public EmployeeRepo(GarageContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Employee entity)
    {
        if (entity is Engineer engineer && !engineer.HasManager)
        {
            throw new InvalidOperationException("An engineer must have a manager.");
        }
        _context.Employees.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var employee = await _context.Employees.SingleOrDefaultAsync(x => x.Id == id);

        if (employee is null)
            return;
        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
    }

    public IAsyncEnumerable<Employee> GetAllAsync()
    {
        return _context.Employees.AsAsyncEnumerable();
    }

    public Task<Employee?> GetByIdAsync(Guid id)
    {
        return _context.Employees.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(Guid id, Employee entity)
    {
        var employee = await GetByIdAsync(id);

        if (employee is null)
            throw new KeyNotFoundException($"Employee {id} was removed in the middle of being updated");
        await _context.SaveChangesAsync();
    }
}