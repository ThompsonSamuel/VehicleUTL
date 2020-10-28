using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleUT.Models.ViewModels {
    public class ServiceVM {
        public Service service { get; set; }

        public IEnumerable<SelectListItem> vehicleSelectList { get; set; }

        public List<SelectListItem> typeService = new List<SelectListItem>() { 
            new SelectListItem { Text = "Service", Value = "Service" }, 
            new SelectListItem{ Text = "Repair", Value = "Repair" },
            new SelectListItem{ Text = "Issue", Value = "Issue" }
        };
    }
}
