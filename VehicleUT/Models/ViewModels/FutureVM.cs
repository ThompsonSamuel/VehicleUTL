using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleUT.Models.ViewModels {
    public class FutureVM {
        public int VehicleId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int timeNext { get; set; }
        public int milesNext { get; set; }
    }
}
