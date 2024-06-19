using Microsoft.AspNetCore.Mvc;
using WebApplication1.Clients;
using WebApplication1.Models.ParcelRegisterModel;
using WebApplication1.Database;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParcelRegisterController : ControllerBase
    {
        private readonly ILogger<ParcelRegisterController> _logger;
        public ParcelRegisterController(ILogger<ParcelRegisterController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [ActionName("AddNewItem")]
        public int ParcelRegister (int user_id, string parcel_code, string parcel_tag, string parcel_description)
        {
            DatabaseModel db_model = new DatabaseModel(user_id, parcel_code, parcel_tag, parcel_description, DateTime.Now);
            ParcelRegisterClient client = new ParcelRegisterClient();
            DatabaseHandler db = new DatabaseHandler ();

            ParcelRegisterModel parcelRegisterModel = client.PostParcelRegisterAsync(db_model.Parcel_code).Result;

            if (parcelRegisterModel.data.rejected.Capacity == 0)
            {
                Task task = db.DB_Data_insert(db_model);
                return 200;
            }
            else
            {
                return parcelRegisterModel.data.rejected.First().error.code;
            }

        }

    }
}
