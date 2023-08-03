using ConsumeApi.Models;
using ConsumeApi.Bussines;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
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
            return View(obj.GetAllEmployees());
        }

        [HttpGet]
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if (obj.AddEmployee(emp))
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(obj.GetEmployee(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(obj.GetEmployee(id));
        }

        [HttpPost]
        public ActionResult Edit(int id,Employee e) 
        {
            if (obj.UpdateEmployee(id,e))
            {
                return RedirectToAction("Index");
            }
            return View("Edit");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(obj.GetEmployee(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id) 
        {
            if (obj.DeleteEmployee(id))
            {
                return RedirectToAction("Index");
            }
            return View("Delete");
        }

    }
}
