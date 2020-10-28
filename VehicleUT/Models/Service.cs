using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleUT.Models
{
    public class Service
    {
        public int VehicleId { get; set; }
        [Key]
        public int ServiceId { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public string Title { get; set; }
        public string Location { get; set; }

        public string Description { get; set; }

        public string Receipt { get; set; }

        [ForeignKey("VehicleId")]
        public virtual Vehicle Vehicle { get; set; }
    }
}
