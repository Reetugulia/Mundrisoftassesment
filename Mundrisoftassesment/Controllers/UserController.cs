using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mundrisoftassesment.Models;
using Mundrisoftassesment.Services;

namespace Mundrisoftassesment.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices userServices;

        public UserController(IUserServices userServices)
        {
            this.userServices = userServices;

        }
        

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult RegisterUser()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterUser(Users user)
        {

            try
            { 

                    int result = userServices.UserRegistration(user);
                    if (result == 1)
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        return View();
                    }
                
            }
            catch (Exception ex)
            {
                return View();
            }
           
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Users user)
        {
            try
            {

                Users signin = userServices.LoginAuthentication(user);
                if (signin != null)
                {
                   
                   
                    HttpContext.Session.SetString("Id", signin.Id.ToString());
                    HttpContext.Session.SetString("EmailId", signin.EmailId);
                    HttpContext.Session.SetString("Roleid", signin.RoleId.ToString());
                    if (signin.RoleId == Convert.ToInt32(Role.Admin))
                    {
                        return RedirectToAction("Index", "Employee");
                    }
                    else
                    {
                        return RedirectToAction("RegisterUser", "User");
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Invalid Email Id or Password";
                }

            }
            catch (Exception ex)
            {
                return View();
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(Users user)
        {
            try
            {

                string userid = HttpContext.Session.GetString("Id");
                user.Id = Convert.ToInt32(userid);
                int result = userServices.UpdatePassword(user);
                if (result == 1)
                {
                    ViewBag.SuccessMessage = "Password Updated Successfully !";
                }
                else
                {
                    ViewBag.ErrorMessage = "Something went wrong!";
                }


            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Something went wrong!";
                return View();
            }
            return View();
        }
      

      
           
    }
}
