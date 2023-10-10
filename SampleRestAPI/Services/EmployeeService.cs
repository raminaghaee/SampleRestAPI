using Microsoft.EntityFrameworkCore;
using SampleRestAPI.DbContext;
using SampleRestAPI.Entities;

namespace SampleRestAPI.Services;

public class EmployeeService : IEmployeeService
{
    private readonly SampleRestDbContext _context;

    public EmployeeService(SampleRestDbContext context)
    {
        _context = context;
    }
    public async Task DeleteEmployeeAsync(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        employee.Status = true;
        await _context.SaveChangesAsync();
    }
    public async Task<bool> EmployeeExist(int id)
    {
        return await _context.Employees.AnyAsync(x => x.Id == id);
    }

    public async Task<List<Employee>> GetAllAsync()
    {
        return await _context.Employees.AsNoTracking().Where(x => x.Status == false).ToListAsync();
    }

    public async Task<Employee> GetByIdAsync(int id)
    {
        return await _context.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Employee> InsertEmployeeAsync(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
        return employee;
    }
    public async Task UpdateEmployeeAsync(Employee employee)
    {
        _context.Entry(employee).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
