using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mundrisoftassesment.Models;
using Mundrisoftassesment.Services;

using System.Net;

namespace Mundrisoftassesment.Controllers
{
    public class EmployeeController : Controller
    {
        Uri weatherurl = new Uri("https://api.openweathermap.org/data/3.0/onecall/timemachine?lat=39.099724&lon=-94.578331&dt=1643803200&appid=58504e2255e9b3cdbd80fa4cb6887c60");
        private readonly IEmployeeServices service;
        
		public EmployeeController(IEmployeeServices service)
        {
            this.service=service;
            
        }
        // GET: EmployeeController
        public IActionResult Index()
        {
            var model=service.GetEmployeeList();
            return View(model);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                int result = service.AddEmployee(emp);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var emp=service.GetEmployeeById(id);
            return View(emp);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            try
            {
                int result=service.ModifyEmployeeDetail(emp);
                if (result == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
               
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public IActionResult Delete(int id)
        {
            var emp = service.GetEmployeeById(id);
            return View(emp);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = service.DeleteEmployee(id);
                if(result==1) 
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            catch(Exception ex)
            {
                return View();
            }
            return View();
        }
       
       


        }
}
