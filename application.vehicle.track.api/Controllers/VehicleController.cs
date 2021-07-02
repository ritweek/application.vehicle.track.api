using application.vehicle.track.model.Contracts;
using application.vehicle.track.provider.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace application.vehicle.track.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleTrackingService _trackingService;

        public VehicleController(IVehicleTrackingService trackingService)
        {
            _trackingService = trackingService;
        }

        [HttpPost]
        [Route("registerVehicle")]
        public async Task<IActionResult> RegisterVehicle([FromBody] VehicleRegistrationRequest vehicleRegistration)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _trackingService.CreateRegistration(vehicleRegistration);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, ex);
            }
        }

        [HttpPost]
        [Route("vehiclePosition")]
        public async Task<IActionResult> UpdateVehiclePosition([FromBody] VehiclePostionRequest vehiclePostionRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _trackingService.InsertVehiclePosition(vehiclePostionRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, ex);
            }
        }

        [HttpGet]
        [Route("currentVehiclePosition")]
        public async Task<IActionResult> GetCurrentPosition(string EmailId, string VehicleRegisterNumber)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _trackingService.GetVehicleCurrentPostion(EmailId,VehicleRegisterNumber);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, ex);
            }
        }

        [HttpGet]
        [Route("allVehiclePosition")]
        public async Task<IActionResult> GetAllVehilePosition(string EmailId, string VehicleRegisterNumber)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _trackingService.GetAllPosition(EmailId, VehicleRegisterNumber);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, ex);
            }
        }
    }
}
