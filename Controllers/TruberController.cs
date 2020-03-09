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
using Microsoft.EntityFrameworkCore;


namespace Truber_Project.Controllers
{
    [Route("truber")]
    public class TruberController : Controller
    {
        private HomeContext dbContext;
        public TruberController(HomeContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            User userInDb = dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
            User userFirstName = dbContext.Users.FirstOrDefault(f => f.FirstName == HttpContext.Session.GetString("UserFirstName"));
            if(userInDb == null)
            {
                return RedirectToAction("LogOut", "Home");
            }
            else
            {
                ViewBag.UserId = userInDb.UserId;
                ViewBag.UserFirstName = userFirstName.FirstName;
                List<Truber> allTrubers = dbContext.Trubers.OrderBy(p => p.Completed != null).OrderBy(m => m.DriverId != null).ToList();
                return View(allTrubers);
            }
        }

        [HttpGet("truber/new")]
        public IActionResult TruberNew()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(Truber newTruber)
        {
            if(ModelState.IsValid)
            {
                newTruber.UserId = (int)HttpContext.Session.GetInt32("UserId");
                newTruber.DriverId = null;
                newTruber.Completed = null;
                dbContext.Add(newTruber);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("TruberNew");
            }
        }

        [HttpGet("delete")]
        public IActionResult Delete(int truberId)
        {
            Truber toDelete = dbContext.Trubers.FirstOrDefault(ee => ee.TruberId == truberId);
            dbContext.Trubers.Remove(toDelete);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("activity/{truberId}")]
        public IActionResult Show(int truberId)
        {
            User userInDb = dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
            Truber Show = dbContext.Trubers.FirstOrDefault( ee => ee.TruberId == truberId );
            ViewBag.UserId = userInDb.UserId;
            return View(Show);
        }
    }
}