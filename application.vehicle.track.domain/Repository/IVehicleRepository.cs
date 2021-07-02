using application.vehicle.track.model.Contracts;
using System.Threading.Tasks;

namespace application.vehicle.track.domain.Repository
{
    public interface IVehicleRepository
    {
        Task<VehicleRegistrationResponse> CreateRegistration(VehicleRegistrationRequest vehicleRegistrationRequest);
        Task<VehiclePositionResponse> InsertVehiclePosition(VehiclePostionRequest vehiclePostionRequest);
        Task<VehiclePositionResponse> GetVehicleCurrentPostion(string EmailId, string VehicleRegistrationNumber);
        Task<VehiclePositionResponse> GetAllPosition(string EmailId, string VehicleRegistrationNumber);
    }
}
