using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace application.vehicle.track.model.Models
{
    public class VehiclePosition
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid RegitrationId { get; set; }
        [Required]
        public decimal Latitude { get; set; }
        [Required]
        public decimal Longitude { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? TimeStamp { get; set; }
    }
}
