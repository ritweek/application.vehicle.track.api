using application.vehicle.track.domain.Repository;
using application.vehicle.track.model.Contracts;
using System.Threading.Tasks;

namespace application.vehicle.track.provider.Services
{
    public class VehicleTrackingService : IVehicleTrackingService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleTrackingService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
       

        public async Task<VehicleRegistrationResponse> CreateRegistration(VehicleRegistrationRequest vehicleRegistrationRequest)
        {
            var result = await _vehicleRepository.CreateRegistration(vehicleRegistrationRequest).ConfigureAwait(false);
            return result;            
        }

        public async Task<VehiclePositionResponse> GetAllPosition(string EmailId, string VehicleRegistrationNumber)
        {
            var result = await _vehicleRepository.GetAllPosition(EmailId,VehicleRegistrationNumber).ConfigureAwait(false);
            return result;
        }

        public async Task<VehiclePositionResponse> GetVehicleCurrentPostion(string EmailId, string VehicleRegistrationNumber)
        {
            var result = await _vehicleRepository.GetVehicleCurrentPostion(EmailId, VehicleRegistrationNumber).ConfigureAwait(false);
            return result;
        }

        public async Task<VehiclePositionResponse> InsertVehiclePosition(VehiclePostionRequest vehiclePostionRequest)
        {
            var result = await _vehicleRepository.InsertVehiclePosition(vehiclePostionRequest);
            return result;
            
        }
    }
}
