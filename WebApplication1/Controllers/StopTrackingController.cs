using Microsoft.AspNetCore.Mvc;
using WebApplication1.Clients;
using WebApplication1.Models.StopTrackingModel;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StopTrackingController : ControllerBase
    {
        private readonly ILogger<StopTrackingController> _logger;
        public StopTrackingController(ILogger<StopTrackingController> logger)
        {
            _logger = logger;
        }

        [HttpDelete]
        [ActionName("StopTracking")]
        public StopTrackingModel StopTracking(string ParcelCode)
        {
            StopTrackingClient client = new StopTrackingClient();
            return client.StopTracking(ParcelCode).Result;
        }

    }
}
