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
            try
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
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool ConsumeQueu<T>(string queue)
        {
            if (_channel == null)
                return false;
            try
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
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CreateExchange(string exchangeName)
        {
            if (_channel == null)
                return false;

            try
            {
                _channel.ExchangeDeclare(exchangeName, ExchangeType.Fanout, durable: true, autoDelete: false, arguments: null);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CreateQueue(string queueName)
        {
            if (_channel == null)
                return false;


            var queu = _channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

            if (queu == null)
                return false;

            return true;
        }

        public bool BindQueue(string exchange, string queue, string routKey)
        {
            if (_channel == null)
                return false;

            try
            {
                _channel.QueueBind(queue, exchange, routKey);

                return false;
            }
            catch
            {
                return true;
            }
        }

        public async Task<bool> SendMessage<T>(T message, string exchange, string routKey)
        {
            if (_channel == null)
                return false;

            try
            {
                await Task.Run(() =>
                {
                    var jsonString = JsonSerializer.Serialize(message);
                    var body = Encoding.UTF8.GetBytes(jsonString);
                    _channel.BasicPublish(exchange,
                        routKey, null, body);

                });
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> SendBasicMessage<T>(T message, string queueName)
        {
            if (_channel == null)
                return false;

            try
            {
                await Task.Run(() =>
                {
                    _channel.QueueDeclare(queue: queueName, false, false, false, arguments: null);
                    var jsonString = JsonSerializer.Serialize(message);
                    var body = Encoding.UTF8.GetBytes(jsonString);
                    _channel.BasicPublish(
                        exchange: "", routingKey: queueName, basicProperties: null, body: body);
                });
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
