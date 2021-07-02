using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace application.vehicle.track.model.Models
{
    public class Registration
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }
        public string DeviceId { get; set; }
        [Required(ErrorMessage = "Please Vehicle Register Number"), MaxLength(20)]
        public string VehicleNumber { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
