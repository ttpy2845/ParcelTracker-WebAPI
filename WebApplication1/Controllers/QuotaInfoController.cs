using Microsoft.AspNetCore.Mvc;
using WebApplication1.Clients;
using WebApplication1.Models.QuotaInfoModel;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class QuotaInfoController : ControllerBase
    {
        private readonly ILogger<QuotaInfoController> _logger;
        public QuotaInfoController(ILogger<QuotaInfoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ActionName("GetModel")]
        public QuotaInfoModel QuotaInfoModel()
        {
            QuotaInfoClient client = new QuotaInfoClient();
            return client.QuotaInfoAsync().Result;
        }

        [HttpGet]
        [ActionName("GetValue")]
        public int QuotaInfoValue()
        {
            QuotaInfoClient client = new QuotaInfoClient();
            return client.QuotaInfoAsync().Result.data.quota_remain;
        }

    }
}
