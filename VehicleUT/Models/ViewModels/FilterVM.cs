using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleUT.Models.ViewModels {
    public class FilterVM {
        public string Name { get; set; }
        public int VehicleID { get; set; }
        public IEnumerable<int> ServiceID { get; set; }
    }
}
