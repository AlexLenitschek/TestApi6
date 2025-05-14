using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApi6.Data;
using TestApi6.Models;
using TestApi6.Models.Entities;

namespace TestApi6.Controllers
{
    //localhost:xxxx/api/employees
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly TestApi6DbContext dbContext;

        public EmployeesController(TestApi6DbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allEmployees = dbContext.Employees.ToList();

            return Ok(allEmployees);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id) 
        {
            var employee = dbContext.Employees.Find(id);

            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var employeeEntity = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary
            };


            dbContext.Add(employeeEntity);
            dbContext.SaveChanges();

            return Ok(employeeEntity);
        }

        // This method uses the Employee entity directly instead of the DTO.
        // This is not a good practice as it exposes the internal structure of the entity.
        //[HttpPost]
        //public IActionResult AddAnotherEmployee(Employee addEmployeeDto)
        //{
        //    dbContext.Add(addEmployeeDto);
        //    dbContext.SaveChanges();
        //    return Ok(addEmployeeDto);
        //}

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = dbContext.Employees.Find(id);

            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone = updateEmployeeDto.Phone;
            employee.Salary = updateEmployeeDto.Salary;

            dbContext.SaveChanges();
            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id) 
        {
            var employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            dbContext.Remove(employee);
            dbContext.SaveChanges();
            return Ok("Employee deleted successfully");
        }

    }
}
