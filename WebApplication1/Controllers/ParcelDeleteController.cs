using Microsoft.AspNetCore.Mvc;
using WebApplication1.Database;
using ParcelTrackerWebAPI.Clients;
using ParcelTrackerWebAPI.Models.ParcelDeleteModel;

namespace ParcelTrackerWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParcelDeleteController : ControllerBase
    {
        private readonly ILogger <ParcelDeleteController> _logger;
        public ParcelDeleteController(ILogger<ParcelDeleteController> logger)
        {
            _logger = logger;
        }

        [HttpDelete]
        [ActionName("ParcelDelete")]
        public int ParcelDelete(string parcel_code)
        {
            ParcelDeleteClient client = new ParcelDeleteClient();
            DatabaseHandler db = new DatabaseHandler();

            ParcelDeleteModel parcelDeleteModel = client.ParcelDelete(parcel_code).Result;
            
            if (parcelDeleteModel.data.rejected == null || parcelDeleteModel.data.rejected.Capacity == 0)
            {
                Task task = db.DB_Data_delete(parcel_code);
                return 200;
            }
            else
            {
                return parcelDeleteModel.data.rejected.First().error.code;
            }

        }
    }
}
