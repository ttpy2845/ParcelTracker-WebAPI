using Microsoft.AspNetCore.Mvc;
using WebApplication1.Clients;
using WebApplication1.Models.TrackingDetailsModel;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrackingDetailsController : ControllerBase
    {
        private readonly ILogger<TrackingDetailsController> _logger;
        public TrackingDetailsController(ILogger<TrackingDetailsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ActionName("TrackingDetails")]
        public TrackingDetailsModel TrackingDetailsModel(string ParcelCode) {

            TrackingDetailsClient client = new TrackingDetailsClient();
            return client.GetTrackingDetailsAsync(ParcelCode).Result;
        }

    }
}
