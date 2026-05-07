using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesApi_NoDb_NoEF.Controllers
{
    // ApiController is a PROPERTY
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        // GET all
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(EmployeeStore.Employees);
        }

        // GET by Id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var emp = EmployeeStore.Employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
                return NotFound("Employee not found");

            return Ok(emp);
        }


        

        // CREATE
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            employee.Id = EmployeeStore.Employees.Max(e => e.Id) + 1;
            EmployeeStore.Employees.Add(employee);

            return Ok(employee);
        }

        // UPDATE
        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee updatedEmp)
        {
            var emp = EmployeeStore.Employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
                return NotFound("Employee not found");

            emp.Name = updatedEmp.Name;
            emp.Role = updatedEmp.Role;
            emp.Salary = updatedEmp.Salary;

            return Ok(emp);
        }












        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var emp = EmployeeStore.Employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
                return NotFound("Employee not found");

            EmployeeStore.Employees.Remove(emp);
            return Ok("Deleted successfully");





        }
    }
}
