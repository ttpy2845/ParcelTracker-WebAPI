using Microsoft.AspNetCore.Mvc;
using WebApplication1.Clients;
using WebApplication1.Controllers;
using WebApplication1.Database;
using WebApplication1.Models;
using WebApplication1.Models.TrackingDetailsModel;

namespace ParcelTrackerWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyParcelsListController : ControllerBase
    {
        private readonly ILogger<MyParcelsListController> _logger;
        public MyParcelsListController(ILogger<MyParcelsListController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ActionName("GetMyList")]
        public async Task <List<DatabaseModel>> GetMyParcelsList (int user_id)
        {
            DatabaseHandler databaseHandler = new DatabaseHandler();
            List <DatabaseModel> result = await databaseHandler.DB_Data_select(user_id);

            return result;
        }

    }
}
