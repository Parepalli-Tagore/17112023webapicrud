using _17112023webapicrud.Models;
using _17112023webapicrud.Services;
using Microsoft.AspNetCore.Mvc;

namespace _17112023webapicrud.Controllers
{
    // EmployeeController.cs
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            try
            {
                var employees = await _employeeService.GetEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeById(id);
                if (employee == null)
                    return NotFound();

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateEmployee(Employee employee)
        {
            try
            {
                var result = await _employeeService.CreateEmployee(employee);
                if (result > 0)
                    return Ok("Employee created successfully");

                return BadRequest("An error occurred while creating the employee");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        public async Task<ActionResult<string>> UpdateEmployee(Employee employee)
        {
            try
            {
                var result = await _employeeService.UpdateEmployee(employee);
                if (result > 0)
                    return Ok("Employee updated successfully");

                return BadRequest("An error occurred while updating the employee");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteEmployee(int id)
        {
            try
            {
                var result = await _employeeService.DeleteEmployee(id);
                if (result > 0)
                    return Ok("Employee deleted successfully");

                return NotFound("Employee not found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
    //    //public IActionResult Index()
    //    //{
    //    //    return View();
    //    //}
    //}
}
