using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MensageryController : ControllerBase
    {
        [HttpPost("ConnectMensagery")]
        public bool Connect()
        {
            bool result = false;

            return false;
        }

        [HttpPost("PublishMensagery")]
        public bool MensageryPublish()
        {
            bool result = false;

            return false;
        }


        [HttpGet("ConsumeMensagery")]
        public bool MensageryConsume()
        {
            bool result = false;





            return false;
        }
    }
}
