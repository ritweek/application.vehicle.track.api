using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.vehicle.track.model.Models
{
    public class Registration
    {
        [Key]
        public Guid MyProperty { get; set; }
        public string EmailId { get; set; }
        public string DeviceId { get; set; }
        public string VehicleNumber { get; set; }
        public int UniqueNumber { get; set; }
    }
}
