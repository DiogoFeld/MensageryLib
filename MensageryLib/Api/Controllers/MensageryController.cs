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

        private readonly MensageryImp _mensagery;

        public MensageryController()
        {
            this._mensagery = new Mensagery("localhost", "guest", "guest", 5672);
        }

        [HttpPost("CreateExchange")]
        public bool CreateExchange(string exchangeName)
        {
            bool result = false;

            _mensagery.CreateExchange(exchangeName);
            return false;
        }

        [HttpPost("CreateQueue")]
        public bool CreateQueue(string queuName)
        {
            bool result = false;

            _mensagery.CreateQueue(queuName);

            return false;
        }

        [HttpPost("BindQueue")]
        public bool BindQueue(BindQueuRequest request)
        {
            bool result = false;
            _mensagery.BindQueue(request.exchange, request.queue, request.routKey);
            return false;
        }

        [HttpPost("PublishMensagery")]
        public bool MensageryPublish(SendMessageRequest<Deposito> request)
        {
            bool result = false;
            _mensagery.SendMessage(request.message, request.exchange, request.routKey);
            return false;
        }

        [HttpPost("MensageryPublishBasicMessage")]
        public bool MensageryPublishBasicMessage(SendMessageSimpleRequest<Deposito> request)
        {
            bool result = false;
            _mensagery.SendBasicMessage(request.message, request.queue);
            return false;
        }        


        [HttpGet("ConsumeMensagery")]
        public bool MensageryConsume(string queueName)
        {
            bool result = false;

            _mensagery.ConsumeQueu<Deposito>(queueName);

            return false;
        }

    }
}
