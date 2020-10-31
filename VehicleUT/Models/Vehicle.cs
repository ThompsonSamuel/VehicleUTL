using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleUT.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        [Required]
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        [Required]
        public int Mileage { get; set; }

        public int milesGone { get; set; }
        [DefaultValue(0.00)]
        public double? fuelUsed { get; set; }

        public bool recordedLastFuel { get; set; }

        public string UserId { get; set; }
        [ForeignKey(name:"UserId")]
        public virtual IdentityUser User { get; set; }
    }
}
