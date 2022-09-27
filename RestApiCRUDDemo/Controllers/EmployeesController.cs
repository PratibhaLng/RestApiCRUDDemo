using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiCRUDDemo.EmployeeData;
using RestApiCRUDDemo.Models;
using System;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace RestApiCRUDDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeData _employeedata;

        public EmployeesController(IEmployeeData employeeData)
        {
            _employeedata = employeeData;


        }

        [HttpGet]
        [Route("api/[controller]")]

        public IActionResult GetEmployees()
        {
            return Ok(_employeedata.GetEmployee());

        }


        [HttpGet]
        [Route("api/[controller]/{Id}")]

        public IActionResult GetEmployees(Guid id)
        {
            var employee = _employeedata.GetEmployee(id);
            if (employee != null)
            {

                return Ok(employee);
            }
            return NotFound($"Employee With Id:{id}  was not found");

        }


        [HttpPost]
        [Route("api/[controller]")]

        public IActionResult GetEmployees(Employee employee)
        {
            _employeedata.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id, employee);
           
           


        }




        [HttpDelete]
        [Route("api/[controller]/{Id}")]
        public IActionResult DeleteEmployee(Guid id)

        {
            var employee = _employeedata.GetEmployee(id);
            if (employee != null)
            {
                _employeedata.DeleteEmployee(employee);
                return Ok();
            }

            return NotFound($"Employee With Id:{id}  was not found");
        }


        [HttpPatch]
        [Route("api/[controller]/{Id}")]
        public IActionResult EditEmployee(Guid id,Employee employee)

        {
            var existingEmployee = _employeedata.GetEmployee(id);
            if (existingEmployee != null)
                employee.Id = existingEmployee.Id;
                _employeedata.EditEmployee(employee);
                return Ok(employee);
            }

            
        


    }
}