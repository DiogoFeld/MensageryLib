using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensageryLib.Services
{
    public interface MensageryImp
    {
        public void ConsumeQueu<T>(string queue);
        public void CreateExchange(string exchangeName);
        public void CreateQueue(string queueName);
        public void BindQueue(string exchange, string queue, string routKey);
        public Task SendMessage<T>(T message, string exchange, string routKey);
        public Task SendBasicMessage<T>(T message, string queueName);


    }
}
