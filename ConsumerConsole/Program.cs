using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Reflection;
using System.Text;

namespace ConsumerConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando Consummer");

            string _hostApi = "amqp://admin:123@192.168.0.150:5672";
            string _queueName = "ParceleDebitosZignet";
            IDictionary<string, object>  _arquments = new Dictionary<string, object> { { "x-queue-type", "quorum" } };
            var _resetEvent = new ManualResetEvent(false);

            try
            {
                var _connectionFactory = new ConnectionFactory { Uri = new Uri(_hostApi) };
                var _connection = _connectionFactory.CreateConnection();

                var _channel = _connection.CreateModel();

                // Cria uma fila caso nao exista. Persistida em caso de restart do broker 
                _channel.QueueDeclare(queue: _queueName, durable: true, exclusive: false, autoDelete: false, arguments: _arquments);

                var consumer = new EventingBasicConsumer(_channel);
                consumer.Received += (sender, e) =>
                {
                    var message = Encoding.UTF8.GetString(e.Body.ToArray());

                    Console.WriteLine("[Processando | " + DateTime.Now.ToString() + "] " + message);
                    Task.Delay(5000).Wait();

                    _channel.BasicAck(e.DeliveryTag, false);

                    // Dispara o evento quando uma mensagem é recebida
                    Console.WriteLine(message);

                    Console.WriteLine("[Processado | " + DateTime.Now.ToString() + "] " + message);
                };

                // Obtém o nome da aplicação
                string appName = Assembly.GetEntryAssembly().GetName().Name;

                // start consuming
                _channel.BasicConsume(consumer, _queueName, false, appName);

                // Wait for the reset event and clean up when it triggers
                _resetEvent.WaitOne();

            }
            catch (Exception ex)
            {
                //RegistraLogService.Log("LerFila: " + ex.Message);
            }
        }
 
    }
}
