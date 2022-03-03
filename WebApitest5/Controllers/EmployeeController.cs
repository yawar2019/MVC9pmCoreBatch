using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApitest5.Models;

namespace WebApitest5.Controllers
{
     
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        public EmployeeContext _employeeContext;
        public EmployeeController(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        [HttpGet("api/getAllEmployee")]
        public IActionResult getEmployeeDetails()
        {
            var res = _employeeContext.employeedet2.ToList();

            return Ok(res);
        }
    }
}
