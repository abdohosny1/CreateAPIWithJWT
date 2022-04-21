#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TTechTack.Data;
using TTechTack.Data.Static;
using TTechTack.Models;

namespace TTechTack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/Employees 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
           var res= await _employeeService.GetAll();
            return Ok(res);
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employeeService.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        
       [Authorize(Roles = UserRoles.Manager)]

        [HttpPut("{id}")]
        public async Task<IActionResult> update(int id, [FromBody] Employee employee)
        {
            var res = await _employeeService.GetById(id);

            if (res == null)
            {
                return NotFound($"Not found Id ={id}");
            }
            else
            {
                res.Name = employee.Name;
                res.Age = employee.Age;
                res.City = employee.City;
                
                _employeeService.Update(res);
                return Ok(res);
            }

        }


       [Authorize(Roles = UserRoles.User)]

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            var res = new Employee() {
                Name = employee.Name,
                City = employee.City,
                Age = employee.Age,
              };

            if (res != null)
            {
                await _employeeService.Add(res);


                return Ok(res);
            }
            else
            {
                return NotFound();
            }
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var res = await _employeeService.GetById(id);

            if (res == null)
            {
                return NotFound($"Not found Id ={id}");
            }
            else
            {
                _employeeService.Delete(res);
                return NoContent();
            }
        }

        //private bool EmployeeExists(int id)
        //{
        //    return _context.Employees.Any(e => e.Id == id);
        //}
    }
}
