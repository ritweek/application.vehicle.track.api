using application.vehicle.track.domain.Data;
using application.vehicle.track.model.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace application.vehicle.track.domain.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VehicleContext _context;

        public VehicleRepository(VehicleContext vehicleContext)
        {
            _context = vehicleContext;
        }
        public async Task<VehicleRegistrationResponse> CreateRegistration(VehicleRegistrationRequest vehicleRegistrationRequest)
        {
            var response = new VehicleRegistrationResponse();
            try
            {
                _context.Registration.Add(vehicleRegistrationRequest.VehicleRegistration);
                await _context.SaveChangesAsync();
                response.VehicleRegistration = vehicleRegistrationRequest.VehicleRegistration;
                response.StatusCode = 200;
                response.Status = "Success";
                return response;
            }
            catch(Exception)
            {
                throw;
            }            
        }

        public Task<VehiclePositionResponse> GetAllPosition(string EmailId, string VehicleRegistrationNumber)
        {
            var response = new VehiclePositionResponse();
            try
            {
                var regitrationId = (from r in _context.Registration
                                      where r.EmailId == EmailId && r.VehicleNumber == VehicleRegistrationNumber
                                      select r.Id).FirstOrDefault();
               //var regitrationId = _context.Registration.Where(x => x.EmailId == EmailId && x.VehicleNumber == VehicleRegistrationNumber).Select(x=>x.Id).FirstOrDefault();
                response.VehiclePositions = _context.VehiclePosition.Where(x => x.RegitrationId == regitrationId).ToList();                
                response.Status = "Success";
                response.StatusCode = 200;
                return Task.FromResult(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<VehiclePositionResponse> GetVehicleCurrentPostion(string EmailId, string VehicleRegistrationNumber)
        {
            var response = new VehiclePositionResponse();
            try
            {
                var regitration = _context.Registration.FirstOrDefault(x => x.EmailId == EmailId && x.VehicleNumber == VehicleRegistrationNumber);
                response.VehiclePositions = _context.VehiclePosition.Where(x => x.RegitrationId == regitration.Id).OrderByDescending(y=>y.TimeStamp).Take(1).ToList();
                response.Status = "Success";
                response.StatusCode = 200;
                return Task.FromResult(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<VehiclePositionResponse> InsertVehiclePosition(VehiclePostionRequest vehiclePostionRequest)
        {
            var response = new VehiclePositionResponse();
            try
            {
                _context.VehiclePosition.Add(vehiclePostionRequest.VehiclePosition);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                response.VehiclePositions.Add(vehiclePostionRequest.VehiclePosition);
                response.Status = "Success";
                response.StatusCode = 200;
                return response;
            }
            catch (Exception)
            {
                throw;
            }            
        }
    }
}
