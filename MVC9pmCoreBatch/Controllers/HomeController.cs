using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MVC9pmCoreBatch.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace MVC9pmCoreBatch.Controllers
{
    
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        //ILogger<HomeController> logger
        private readonly IConfiguration _configuration;
        private readonly IRepository _repository;
        public HomeController(IConfiguration configuration,IRepository repository)
        {
            _configuration = configuration;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult SendData()
        {
            EmployeeModel emp = new EmployeeModel();
            emp.EmpId = 1;
            emp.EmpName = "Bindu";
            emp.EmpSalary = 12344;

            return View(emp);
        }

        [Route("Jungle/Tiger/{id:int?}")]
        [Route("Jungle/cheetah")]
        public ActionResult SendMultipleData(string id)
        {
            List<EmployeeModel> listemp = new List<EmployeeModel>();
            EmployeeModel emp = new EmployeeModel();
            emp.EmpId = 1;
            emp.EmpName = "Bindu";
            emp.EmpSalary = 12344;

            EmployeeModel emp1 = new EmployeeModel();
            emp1.EmpId = 2;
            emp1.EmpName = "Prakash";
            emp1.EmpSalary = 52344;

            listemp.Add(emp);
            listemp.Add(emp1);

            return View(listemp);
        }
        EmployeeContext db = new EmployeeContext();

        public ActionResult GetEmployees()
        {
            string conn = this._configuration.GetConnectionString("Default");
            List<EmployeeModel> Emp = _repository.GetEmployees(conn);
            //var Emp = db.GetEmployees(conn);
         //   SqlConnection con = new SqlConnection(conn);
           // List<EmployeeModel> Emp = con.Query<EmployeeModel>("sp_getEmployee_Rock", commandType: System.Data.CommandType.StoredProcedure).ToList();
            return View(Emp);
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel emp)
        {
            string conn = this._configuration.GetConnectionString("Default");
            SqlConnection con = new SqlConnection(conn);
            var param = new DynamicParameters();
            param.Add("@EmpName", emp.EmpName);
            param.Add("@EmpSalary", emp.EmpSalary);
            
            //int i = db.SaveEmployee(conn, emp);
            int i = con.Execute("sp_AddNeerjaEmployees",param: param, commandType: System.Data.CommandType.StoredProcedure);

            if (i>0)
            {
                return RedirectToAction("GetEmployees");
            }
             
            return View();
        }

        public ViewResult Edit(int? id)
        {
            string conn = this._configuration.GetConnectionString("Default");
            EmployeeModel emp = db.GetEmployeesById(id,conn);
            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel emp)
        {
            string conn = this._configuration.GetConnectionString("Default");

            int i = db.SaveEmployee(conn, emp);

            if (i > 0)
            {
                return RedirectToAction("GetEmployees");
            }

            return View();
        }




    }
}
