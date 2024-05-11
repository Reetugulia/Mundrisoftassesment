using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mundrisoftassesment.Models;
using Mundrisoftassesment.Services;

namespace Mundrisoftassesment.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices service;
        // GET: DepartmentController
        public DepartmentController(IDepartmentServices service)
        {
            this.service=service;
        }
        public ActionResult Index()
        {
            var model = service.GetAllDepartmentList();
            return View(model);
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department dp)
        {
            try
            {
                int result = service.AddDepartment(dp);
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

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            var dp = service.GetDepartmentById(id);
            return View(dp);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department dp)
        {
            try
            {
                int result = service.ModifyDepartment(dp);
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

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            var dp = service.GetDepartmentById(id);
            return View(dp);
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = service.DeleteDepartment(id);
                if (result == 1)
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception ex)
            {
                return View();
            }
            return View();
        }
    }
}
