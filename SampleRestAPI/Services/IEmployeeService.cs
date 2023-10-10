using SampleRestAPI.Entities;

namespace SampleRestAPI.Services;

public interface IEmployeeService
{
    Task<List<Employee>> GetAllAsync();
    Task<Employee> GetByIdAsync(int id);
    Task<Employee> InsertEmployeeAsync(Employee employee);
    Task UpdateEmployeeAsync(Employee employee);
    Task DeleteEmployeeAsync(int id);
    Task<bool> EmployeeExist(int id);
}
