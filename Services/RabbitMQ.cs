using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Services
{
    public class ServciceRabbitMQ
    {
        private string _hostApi;
        private string _queueName;
        private ManualResetEvent _resetEvent;
        private ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _channel;

        public event EventHandler<string> MessageReceived;
        public event EventHandler<string> MessageReceivedLog;

        public ServciceRabbitMQ()
        {
            _hostApi = "amqp://guest:guest@192.168.0.150:5672";
            _queueName = "ParceleDebitosZignet";
            _resetEvent = new ManualResetEvent(false);
        }

        public async Task AddMessage(string _mensage)
        {
            // minha operação de execução longa
            var writeQueue = new { Mensagem = _mensage };

            var factory = new ConnectionFactory { Uri = new Uri(_hostApi) };

            try
            {
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        // Cria uma fila caso nao exista. Persistida em caso de restart do broker 
                        channel.QueueDeclare(queue: _queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

                        var body = Encoding.UTF8.GetBytes(writeQueue.Mensagem);
                        channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);

                        //RegistraLogService.Log(" Enviado: " + writeQueue.Mensagem);
                    }
                }
            }
            catch (Exception ex)
            {
                //RegistraLogService.Log("Erro AdicionarNaFila: " + _mensagem + '\n' + ex.Message);
            }

        }

        public async Task StartConsumer(string comsumerTag)
        {
            //RegistraLogService.Log("Iniciando o Consumer.");

            try
            {
                _connectionFactory = new ConnectionFactory { Uri = new Uri(_hostApi) };

                _connection = _connectionFactory.CreateConnection();

                _channel = _connection.CreateModel();

                // Cria uma fila caso nao exista. Persistida em caso de restart do broker 
                _channel.QueueDeclare(queue: _queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

                var consumer = new EventingBasicConsumer(_channel);
                consumer.Received += Consumer_Received;

                // start consuming
                _channel.BasicConsume(consumer, _queueName, false, comsumerTag);

                // Wait for the reset event and clean up when it triggers
                _resetEvent.WaitOne();

            }
            catch (Exception ex)
            {
                //RegistraLogService.Log("LerFila: " + ex.Message);
            }
        }

        public async Task StopConsumer()
        {
            _resetEvent.Set();

            // Fecha o canal e a conexão
            if (_channel != null && _channel.IsOpen)
            {
                _channel.Close();
                _channel.Dispose();
            }

            if (_connection != null && _connection.IsOpen)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }
        private void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Body.ToArray());

            MessageReceivedLog?.Invoke(this, "[Processando | " + DateTime.Now.ToString() + "] " + message);

            Task.Delay(5000).Wait();

            _channel.BasicAck(e.DeliveryTag, false);

            // Dispara o evento quando uma mensagem é recebida
            MessageReceived?.Invoke(this, message);


            MessageReceivedLog?.Invoke(this, "[Processado | " + DateTime.Now.ToString() + "] " + message);
        }

    }
}
