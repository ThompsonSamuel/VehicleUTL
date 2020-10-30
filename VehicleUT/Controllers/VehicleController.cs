using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using VehicleUT.Models;

namespace VehicleUT.Controllers {
    [Authorize]
    public class VehicleController : Controller {
        private readonly AppDbContext db;
        private readonly UserManager<IdentityUser> userManager;
        public VehicleController(AppDbContext db, UserManager<IdentityUser> userManager) {
            this.db = db;
            this.userManager = userManager;
        }

        public IActionResult Index() {
            IEnumerable<Vehicle> vehicles = db.Vehicle.Where(c => c.UserId == userManager.GetUserId(HttpContext.User));
            return View(vehicles);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Vehicle vehicle) {
            if (ModelState.IsValid) {
                vehicle.UserId = userManager.GetUserId(HttpContext.User);
                db.Vehicle.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        public IActionResult Edit(int id) {
            var vehicle = db.Vehicle.Find(id);
            if (vehicle == null) {
                return NotFound();
            }
            return View(vehicle);
        }

        [HttpPost]
        public IActionResult Edit(Vehicle vehicle) {
            if (ModelState.IsValid) {
                Vehicle dbVehicle = db.Vehicle.Find(vehicle.VehicleId);
                Vehicle newData = 

                db.Vehicle.Update(vehicle);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        public IActionResult Delete(int id) {
            var vehicle = db.Vehicle.Find(id);
            if (vehicle == null) {
                return NotFound();
            }
            db.Vehicle.Remove(vehicle);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //[HttpPost]
        //public IActionResult Delete(Vehicle vehicle) {
        //    db.Vehicle.Remove(vehicle);
        //    db.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}

    }
}
