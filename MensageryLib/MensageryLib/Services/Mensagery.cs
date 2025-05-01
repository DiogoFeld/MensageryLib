using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Text.Json;

namespace MensageryLib.Services
{
    public class Mensagery<T>
    {
        private IConnection _connection;
        private IModel _channel;

        public Mensagery(string clientName, string userName, string password)
        {
            _channel = CreateConnection(clientName, userName, password);
        }

        private IModel? CreateConnection(string clientName, string userName, string password)
        {
            var factory = new ConnectionFactory
            {
                HostName = clientName,
                UserName = userName,
                Password = password,
                Port = 5672
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            return _channel;
        }

        public void ConsumeQueu(string queue)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                try
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine($"message Received: : {message}");

                    T objectMessage = JsonSerializer.Deserialize<T>(message);

                    _channel.BasicAck(ea.DeliveryTag, false);
                }
                catch (Exception ex)
                {
                    _channel.BasicAck(ea.DeliveryTag, false);
                }
            };

            // Consumir mensagens da fila
            _channel.BasicConsume(queue: queue,
                                 autoAck: true,
                                 consumer: consumer);
        }






    }
}
