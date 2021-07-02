using application.vehicle.track.model.Models;
using System.Collections.Generic;

namespace application.vehicle.track.model.Contracts
{
    public class VehiclePositionResponse : ResponseBase
    {
        public VehiclePositionResponse()
        {
            VehiclePositions = new List<VehiclePosition>();
        }
        public List<VehiclePosition> VehiclePositions { get; set; }
    }
}
