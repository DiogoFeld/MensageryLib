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
            return _mensagery.CreateExchange(exchangeName);
        }

        [HttpPost("CreateQueue")]
        public bool CreateQueue(string queuName)
        {
            return _mensagery.CreateQueue(queuName);
        }

        [HttpPost("BindQueue")]
        public bool BindQueue(BindQueuRequest request)
        {
            return  _mensagery.BindQueue(request.Exchange, request.Queue, request.RoutKey);        
        }

        [HttpPost("PublishMensagery")]
        public async Task<bool> MensageryPublish(SendMessageRequest<Deposito> request)
        {
            return await _mensagery.SendMessage(request.Message, request.Exchange, request.RoutKey);
        }

        [HttpPost("MensageryPublishBasicMessage")]
        public async Task<bool> MensageryPublishBasicMessage(SendMessageSimpleRequest<Deposito> request)
        {
            return await _mensagery.SendBasicMessage(request.Message, request.Queue);
            
        }        


        [HttpGet("ConsumeMensagery")]
        public bool MensageryConsume(string queueName)
        {
            return _mensagery.ConsumeQueu<Deposito>(queueName);
        }

    }
}
