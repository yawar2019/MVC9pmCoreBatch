using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    
    [ApiController]
    public class ApiController : ControllerBase
    {
        private EmployeeContext _empContext;
        public ApiController(EmployeeContext emp)
        {
            _empContext = emp;
        }
        [HttpGet("api/testEmployee")]
        public IActionResult GetEmployee()
        {
            var res = _empContext.employeeDetails.ToList();
            return Ok(res);
        }

        [HttpPost("api/SaveEmployee")]
        public IActionResult PostEmployee(employeeDetails details)
        {
            _empContext.employeeDetails.Add(details);
            _empContext.SaveChanges();
            return Created("api/testEmployee", details);
        }

        [HttpPut("api/UpdateEmployee/{id}")]
        public IActionResult PutEmployee(int id, employeeDetails details)
        {
            var emp = _empContext.employeeDetails.Find(id);
            if (emp.EmpId != id)
            {
                return NotFound();
            }
            else
            {
                emp.EmpName = details.EmpName;
                emp.EmpSalary = details.EmpSalary;

                _empContext.SaveChanges();
                return StatusCode(204);
            }
        }

        [HttpDelete("api/DeleteEmployee/{id}")]
        public IActionResult deleteEmployee(int id)
        {
            var emp = _empContext.employeeDetails.Find(id);
            if (emp.EmpId > 0)
            {
                _empContext.employeeDetails.Remove(emp);
                _empContext.SaveChanges();
                return Ok();
            }
            else
            {
                return NoContent();

            }
        }

    }
}
