using Api.Controllers.Models;
using Api.Controllers.Models.Request;
using MensageryLib.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MensageryController : ControllerBase
    {

        private readonly MensageryImp mensagery;

        public MensageryController()
        {
            //                this.mensagery = new Mensagery("localhost", "guest", "guest", 5672);
        }

        [HttpPost("CreateExchange")]
        public bool CreateExchange(string exchangeName)
        {
            bool result = false;

            return false;
        }

        [HttpPost("CreateQueue")]
        public bool CreateQueue(string queuName)
        {
            bool result = false;

            return false;
        }

        [HttpPost("BindQueue")]
        public bool BindQueue(BindQueuRequest request)
        {
            bool result = false;

            return false;
        }

        [HttpPost("PublishMensagery")]
        public bool MensageryPublish(SendMessageRequest<Deposito> request)
        {
            bool result = false;

            return false;
        }


        [HttpGet("ConsumeMensagery")]
        public bool MensageryConsume(string queueName)
        {
            bool result = false;

            return false;
        }



    }
}
