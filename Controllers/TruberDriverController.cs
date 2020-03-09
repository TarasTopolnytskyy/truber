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
    [Route("truber/driver")]
    public class TruberDriverController : Controller
    {
        private HomeContext dbContext;
        public TruberDriverController(HomeContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            Driver driverInDb = dbContext.Drivers.FirstOrDefault(u => u.DriverId == HttpContext.Session.GetInt32("DriverId"));
            Driver driverFirstName = dbContext.Drivers.FirstOrDefault(f => f.FirstName == HttpContext.Session.GetString("DriverFirstName"));
            if(driverInDb == null)
            {
                return RedirectToAction("LogOut", "Home");
            }
            else
            {
                ViewBag.DriverId = driverInDb.DriverId;
                ViewBag.DriverFirstName = driverFirstName.FirstName;
                List<Truber> allTrubers = dbContext.Trubers.OrderBy(p => p.Completed != null).OrderBy(m => m.DriverId != null).ToList();
                return View(allTrubers);
            }
        }

        [HttpGet("activity/truberdriver/{truberId}")]
        public IActionResult ShowJob(int truberId)
        {
            Driver driverInDb = dbContext.Drivers.FirstOrDefault(u => u.DriverId == HttpContext.Session.GetInt32("DriverId"));
            Truber Show = dbContext.Trubers.FirstOrDefault( ee => ee.TruberId == truberId );
            ViewBag.DriverId = driverInDb.DriverId;
            return View(Show);
        }

        [HttpGet("take/{truberId}")]
        public IActionResult TakeJob(int truberId)
        {
            Truber toTake = dbContext.Trubers.FirstOrDefault(ee => ee.TruberId == truberId);
            toTake.DriverId = HttpContext.Session.GetInt32("DriverId");
            toTake.UpdatedAt = DateTime.Now;
            dbContext.SaveChanges();
            return Redirect($"/truber/driver/activity/truberdriver/{truberId}");
        }

        [HttpGet("drop/{truberId}")]
        public IActionResult DropJob(int truberId)
        {
            Truber toDrop = dbContext.Trubers.FirstOrDefault(ee => ee.TruberId == truberId);
            toDrop.DriverId = null;
            toDrop.UpdatedAt = DateTime.Now;
            dbContext.SaveChanges();
            return Redirect($"/truber/driver/activity/truberdriver/{truberId}");
        }

        [HttpGet("truberdriver/jobs")]
        public IActionResult DriverJob()
        {
            Driver driverInDb = dbContext.Drivers.FirstOrDefault(u => u.DriverId == HttpContext.Session.GetInt32("DriverId"));
            List<Truber> allJobs = dbContext.Trubers.OrderBy(p => p.Completed != null).OrderBy(m => m.DriverId != null).Where(ee => ee.DriverId == HttpContext.Session.GetInt32("DriverId")).ToList();
            ViewBag.DriverId = driverInDb.DriverId;
            return View(allJobs);
        }

        [HttpGet("completed/{truberId}")]
        public IActionResult Completed(int truberId)
        {
            Truber toComplete = dbContext.Trubers.FirstOrDefault(ee => ee.TruberId == truberId);
            toComplete.Completed = HttpContext.Session.GetInt32("DriverId");
            toComplete.UpdatedAt = DateTime.Now;
            dbContext.SaveChanges();
            return Redirect($"/truber/driver/truberdriver/jobs");
        }
    }
}