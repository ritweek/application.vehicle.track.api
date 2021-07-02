using application.vehicle.track.model.Models;

namespace application.vehicle.track.model.Contracts
{
    public class VehicleRegistrationResponse: ResponseBase
    {
        public Registration VehicleRegistration { get; set; }
    }
}
