using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using VehicleUT.Models;
using VehicleUT.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace VehicleUT.Controllers {
    [Authorize]
    public class ServiceController : Controller {
        private readonly AppDbContext db;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ServiceController(AppDbContext db, UserManager<IdentityUser> userManager, IWebHostEnvironment webHostEnvironment) {
            this.db = db;
            this.userManager = userManager;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index() {
            IEnumerable<Vehicle> vehicles = db.Vehicle.Where(x => x.UserId == userManager.GetUserId(HttpContext.User));
            List<FilterVM> filters = new List<FilterVM>();
            foreach (var i in vehicles) {
                filters.Add(new FilterVM {
                    Name = i.Make + ' ' + i.Model + ' ' + i.Year,
                    VehicleID = i.VehicleId,
                    ServiceID = db.Service.Where(c => c.VehicleId == i.VehicleId).Select(c => c.ServiceId)
                });
            }
            return View(filters);
        }

        public IActionResult GetEvents() {
            IEnumerable<Service> services = db.Service.Where(c => db.Vehicle.Where(x => x.UserId == userManager.GetUserId(HttpContext.User)).Any(x => x.VehicleId == c.VehicleId));
            var events = services.Select(c => new {
                edit = "/Edit/" + c.ServiceId,
                title = c.Title,
                start = c.Date.ToString("yyyy-MM-ddTHH:mm"),
                allDay = false,
                backgroundColor = SetColor(c.Title),
                description = c.Description,
                receipt = Startup.ImagePath + c.Receipt,
                location = c.Location,
                delete = "/Delete/" + c.ServiceId,
                id = c.ServiceId
            });
            return new JsonResult(events);
        }

        public string SetColor(string title) {
            if (title == "Service")
                return "#007bff";
            else if (title == "Repair")
                return "#dc3545";
            else //(title == "Issue")
                return "#ffc107";
        }

        public IActionResult Create() {
            ServiceVM serviceVM = new ServiceVM() {
                service = new Service(),
                vehicleSelectList = db.Vehicle.Where(c => c.UserId == userManager.GetUserId(HttpContext.User)).Select(c => new SelectListItem {
                    Text = c.Make + ' ' + c.Model + ' ' + c.Year,
                    Value = c.VehicleId.ToString()
                })
            };

            return View(serviceVM);
        }

        [HttpPost]
        public IActionResult Create(ServiceVM serviceVM) {
            if (ModelState.IsValid) {
                var files = HttpContext.Request.Form.Files;
                string webRootPath = webHostEnvironment.WebRootPath;
                if (files.Count > 0) {
                    string upload = webRootPath + Startup.ImagePath;
                    string fileName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(files[0].FileName);
                    using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create)) {
                        files[0].CopyTo(fileStream);
                    }
                    serviceVM.service.Receipt = fileName + extension;
                }

                db.Service.Add(serviceVM.service);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceVM.service);
        }

        [HttpPost]
        public void CreateFuture(ServiceVM serviceVM) {
            if (ModelState.IsValid) {
                if (serviceVM.milesNext > 0) {
                    serviceVM.service.serviceMiles = db.Vehicle.Find(serviceVM.service.VehicleId).Mileage + serviceVM.milesNext;
                }
                if (serviceVM.timeNext > 0) {
                    serviceVM.service.Date = serviceVM.service.Date.AddMonths(serviceVM.timeNext);
                }
                db.Service.Add(serviceVM.service);
                db.SaveChanges();
            }
        }

        public IActionResult Edit(int id) {
            var serviceids = db.Service.Where(c => db.Vehicle.Where(x => x.UserId == userManager.GetUserId(HttpContext.User)).Any(x => x.VehicleId == c.VehicleId)).Select(c => c.ServiceId);
            if (serviceids.Contains(id)) {
                ServiceVM serviceVM = new ServiceVM() {
                    service = new Service(),
                    vehicleSelectList = db.Vehicle.Where(c => c.UserId == userManager.GetUserId(HttpContext.User)).Select(c => new SelectListItem {
                        Text = c.Make + ' ' + c.Model + ' ' + c.Year,
                        Value = c.VehicleId.ToString()
                    }),
                };
                serviceVM.service = db.Service.Find(id);
                return View(serviceVM);
            }
            else {
                return RedirectToAction(nameof(Index));
            }

        }

        [HttpPost]
        public IActionResult Edit(ServiceVM serviceVM) {
            var DBService = db.Service.AsNoTracking().FirstOrDefault(c => c.ServiceId == serviceVM.service.ServiceId);
            var files = HttpContext.Request.Form.Files;
            string webRootPath = webHostEnvironment.WebRootPath;
            if (files.Count > 0) {
                string upload = webRootPath + Startup.ImagePath;
                string fileName = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(files[0].FileName);
                //remove the old image
                if (DBService.Receipt != null) {
                    var oldFile = Path.Combine(upload, DBService.Receipt);
                    if (System.IO.File.Exists(oldFile)) {
                        System.IO.File.Delete(oldFile);
                    }
                }
                //add new
                using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create)) {
                    files[0].CopyTo(fileStream);
                }
                serviceVM.service.Receipt = fileName + extension;
            }
            else {
                serviceVM.service.Receipt = DBService.Receipt;
            }
            db.Service.Update(serviceVM.service);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) {
            Service service = db.Service.Find(id);
            if (service != null) {
                if (service.Receipt != null) {
                    var reciept = Path.Combine(webHostEnvironment.WebRootPath + Startup.ImagePath, service.Receipt);
                    if (System.IO.File.Exists(reciept)) {
                        System.IO.File.Delete(reciept);
                    }
                }
                db.Service.Remove(service);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}