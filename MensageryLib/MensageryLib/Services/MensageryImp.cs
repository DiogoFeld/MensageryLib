using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensageryLib.Services
{
    public interface MensageryImp
    {
        public bool ConsumeQueu<T>(string queue);
        public bool CreateExchange(string exchangeName);
        public bool CreateQueue(string queueName);
        public bool BindQueue(string exchange, string queue, string routKey);
        public Task<bool> SendMessage<T>(T message, string exchange, string routKey);
        public Task<bool> SendBasicMessage<T>(T message, string queueName);
        public Task<bool> SendMessagePersistent<T>(T message, string exchange, string routKey, int numberOfTries);

    }
}
