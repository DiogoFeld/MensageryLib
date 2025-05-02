using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Text.Json;

namespace MensageryLib.Services
{
    public class Mensagery : MensageryImp
    {
        private IConnection _connection;
        private IModel _channel;

        public Mensagery(string host, string userName, string password, int port)
        {
            _channel = CreateConnection(host, userName, password, port);
        }

        private IModel? CreateConnection(string host, string userName, string password, int port)
        {
            var factory = new ConnectionFactory
            {
                HostName = host,
                UserName = userName,
                Password = password,
                Port = port
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            return _channel;
        }

        public void ConsumeQueu<T>(string queue)
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

        public void CreateExchange(string exchangeName)
        {
            _channel.ExchangeDeclare(exchangeName, ExchangeType.Fanout, durable: true, autoDelete: false,arguments: null);
        }

        public void CreateQueue(string queueName)
        {
            _channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false,arguments: null);
        }

        public void BindQueue(string exchange, string queue, string routKey)
        {
            _channel.QueueBind(queue,exchange,routKey);
        }

        public async Task SendMessage<T>(T message, string exchange,string routKey)
        {
            try
            {
                await Task.Run(() =>
                {
                    var jsonString = JsonSerializer.Serialize(message);
                    var body = Encoding.UTF8.GetBytes(jsonString);
                    _channel.BasicPublish(exchange,
                        routKey, null, body);
                });

            }
            catch (Exception ex){ }
        }


    }
}
