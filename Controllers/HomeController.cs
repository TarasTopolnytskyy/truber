using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Truber_Project.Models;
using Truber_Project.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;


namespace Truber_Project.Controllers
{
    public class HomeController : Controller
    {

        private HomeContext dbContext;

        public HomeController(HomeContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(User register)
        {
            if(ModelState.IsValid)
            {
                if(dbContext.Users.Any(u => u.Email == register.Email))
                {
                    ModelState.AddModelError("Email", "The email already exists.");
                    return View("Index");
                }
                else
                {
                    PasswordHasher<User> hash = new PasswordHasher<User>();
                    register.Password = hash.HashPassword(register, register.Password);

                    dbContext.Users.Add(register);
                    dbContext.SaveChanges();
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet("Login/driver")]
        public IActionResult LoginDriver()
        {
            return View();
        }

        [HttpGet("driver/register")]
        public IActionResult DriverRegister()
        {
            return View();
        }

        [HttpPost("register/driver")]
        public IActionResult RegisterDriver(Driver register)
        {
            if(ModelState.IsValid)
            {
                if(dbContext.Drivers.Any(u => u.Email == register.Email))
                {
                    ModelState.AddModelError("Email", "The email already exists.");
                    return View("Index");
                }
                else
                {
                    PasswordHasher<Driver> hash = new PasswordHasher<Driver>();
                    register.Password = hash.HashPassword(register, register.Password);

                    dbContext.Drivers.Add(register);
                    dbContext.SaveChanges();
                    return RedirectToAction("Index", "TruberDriver");
                }
            }
            else
            {
                return View("Index");
            }
        }

        [HttpPost("signin")]
        public IActionResult SignIn(LoginUser login)
        {
            if(ModelState.IsValid)
            {
                User userInDb = dbContext.Users.FirstOrDefault(u => u.Email == login.LoginEmail);
                if(userInDb == null)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid email/Password");
                    return View("Login");
                }
                else
                {
                    PasswordHasher<LoginUser> compare = new PasswordHasher<LoginUser>();
                    var result = compare.VerifyHashedPassword(login, userInDb.Password, login.LoginPassword);
                    if(result == 0)
                    {
                        ModelState.AddModelError("LoginEmail", "Invalid email/Password");
                        return View("Login");
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                        HttpContext.Session.SetString("UserFirstName", userInDb.FirstName);
                        return RedirectToAction("Index","Truber");
                    }
                }
            }
            else
            {
                return View("Login");
            }
        }

        [HttpPost("signin/driver")]
        public IActionResult SignInDriver(LoginDriver login)
        {
            if(ModelState.IsValid)
            {
                Driver driverInDb = dbContext.Drivers.FirstOrDefault(u => u.Email == login.LoginDriverEmail);
                if(driverInDb == null)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid email/Password");
                    return View("Login");
                }
                else
                {
                    PasswordHasher<LoginDriver> compare = new PasswordHasher<LoginDriver>();
                    var result = compare.VerifyHashedPassword(login, driverInDb.Password, login.LoginDriverPassword);
                    if(result == 0)
                    {
                        ModelState.AddModelError("LoginEmail", "Invalid email/Password");
                        return View("LoginDriver");
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("DriverId", driverInDb.DriverId);
                        HttpContext.Session.SetString("DriverFirstName", driverInDb.FirstName);
                        return RedirectToAction("Index","TruberDriver");
                    }
                }
            }
            else
            {
                return View("LoginDriver");
            }
        }


        [HttpGet("logout")]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
