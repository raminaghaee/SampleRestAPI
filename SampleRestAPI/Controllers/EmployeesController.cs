using Microsoft.AspNetCore.Mvc;
using SampleRestAPI.Entities;
using SampleRestAPI.Services;

namespace SampleRestAPI.Controllers;

[ApiController]
//با [] باشد
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employee;
    //استفاده از اینترفیس و null بودن آن 

    public EmployeesController(IEmployeeService employee = null)
    {
        _employee = employee;
    }
    [HttpGet]
    //Get : api/employees
    public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
    {
        return Ok(await _employee.GetAllAsync());
    }

    [HttpGet("{id}")]
    //Get : api/employees/5
    public async Task<ActionResult<Employee>> GetEmployee(int id)
    {
        var result = await _employee.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
    [HttpPut("{id}")]
    //put : api/employees/5
    public async Task<ActionResult> PutEmployee(int id, Employee employee)
    {
        if (id != employee.Id)
        {
            return BadRequest();
        }
        if (!await _employee.EmployeeExist(id))
        {
            return NotFound();
        }
        await _employee.UpdateEmployeeAsync(employee);
        return Ok();
    }
    [HttpPost]
    //Post : api/employees
    //به هیچ دیتا دتسی داخل دیتابیس ایجاد نکن چون orm قاطی میکنه
    public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
    {
        var result = await _employee.InsertEmployeeAsync(employee);
        return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Employee>> DeleteEmployee(int id)
    {
        var employee = await _employee.GetByIdAsync(id);

        if (employee == null)
            return NotFound();

        await _employee.DeleteEmployeeAsync(id);
        return Ok();
    }
}
