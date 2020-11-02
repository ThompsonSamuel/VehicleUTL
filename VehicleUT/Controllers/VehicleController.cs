using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            DateTime today = DateTime.Today;
            IEnumerable<Vehicle> vehicles = db.Vehicle.Where(c => c.UserId == userManager.GetUserId(HttpContext.User));
            IEnumerable<Service> services = db.Service.Where(c => vehicles.Any(x => x.VehicleId == c.VehicleId));
            int j = 0;
            foreach (var i in services) {
                int temp = vehicles.FirstOrDefault(c => c.VehicleId == i.VehicleId).Mileage;
                if ((i.serviceMiles - temp > 0 && i.serviceMiles - temp <= 100) || i.Date > today && i.Date <= today.AddDays(7))
                    j++;
            }
            ViewBag.alert = services;
            ViewBag.count = j;
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
                db.Vehicle.Update(vehicle);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        public IActionResult Update(Vehicle vehicle) {
            if (ModelState.IsValid) {
                Vehicle dbVehicle = db.Vehicle.AsNoTracking().FirstOrDefault(c => c.VehicleId == vehicle.VehicleId);
                Vehicle newData = new Vehicle() {
                    milesGone = dbVehicle.recordedLastFuel == true && vehicle.fuelUsed != null ? dbVehicle.milesGone += vehicle.Mileage - dbVehicle.Mileage : dbVehicle.milesGone,
                    fuelUsed = dbVehicle.recordedLastFuel == true && vehicle.fuelUsed != null ? dbVehicle.fuelUsed + vehicle.fuelUsed : dbVehicle.fuelUsed,
                    recordedLastFuel = vehicle.fuelUsed == null ? false : true,
                    VehicleId = dbVehicle.VehicleId,
                    Make = dbVehicle.Make,
                    Model = dbVehicle.Model,
                    Year = dbVehicle.Year,
                    Mileage = vehicle.Mileage,
                    UserId = dbVehicle.UserId
                };

                db.Vehicle.Update(newData);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Index));
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
