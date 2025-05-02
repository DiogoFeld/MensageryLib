using MensageryLib.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MensageryController : ControllerBase
    {

        private readonly MensageryImp mensagery;

        public MensageryController(MensageryImp mensagery)
        {
            mensagery = new Mensagery("localhost", "guest", "guest", 5672);
        }

        [HttpPost("ConnectMensagery")]
        public bool Connect()
        {
            bool result = false;

            return false;
        }

        [HttpPost("CreateExchange")]
        public bool CreateExchange()
        {
            bool result = false;

            return false;
        }

        [HttpPost("CreateQueue")]
        public bool CreateQueue()
        {
            bool result = false;

            return false;
        }

        [HttpPost("BindQueue")]
        public bool BindQueue()
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
