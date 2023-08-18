using ConsumeApi.Models;
using ConsumeApi.Bussines;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using Serilog;

namespace ConsumeApi.Controllers
{
    public class ConsumeController1 : Controller
    {
        BL obj = new BL();

        // GET: Consume
        HttpClient client = new HttpClient();
        [HttpGet]
        public ActionResult Index()
        {
            Log.Information("Check all Employees data");
            return View(obj.GetAllEmployees());
        }

        [HttpGet]
        public ActionResult Create() {
            Log.Information("Start creating New Employee");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if (obj.AddEmployee(emp))
            {
                Log.Information("New Employee Created Successfully");
                return RedirectToAction("Index");
            }
            return View("Create");

        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Log.Information("Check detail of Employee");
            return View(obj.GetEmployee(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Log.Information("Start Editing Employee data");
            return View(obj.GetEmployee(id));
        }

        [HttpPost]
        public ActionResult Edit(int id,Employee e) 
        {
            if (obj.UpdateEmployee(id,e))
            {
                Log.Information("Employee Data Edited Successfully");
                return RedirectToAction("Index");
            }
            
            return View("Edit");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Log.Information("Start Deleting Employee");
            return View(obj.GetEmployee(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id) 
        {
            if (obj.DeleteEmployee(id))
            {
                Log.Information("Employee Deleted Successfully");
                return RedirectToAction("Index");
            }
            return View("Delete");
        }

    }
}
