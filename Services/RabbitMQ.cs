using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Services
{
    public class ServciceRabbitMQ
    {
        private string _hostApi;
        private string _queueName;

        public ServciceRabbitMQ()
        {
            _hostApi = "amqp://guest:guest@192.168.0.150:5672";
            _queueName = "ParceleDebitosZignet";
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

        public async Task StartConsumer()
        {
            //RegistraLogService.Log("Iniciando o Consumer.");

            var resetEvent = new ManualResetEvent(false);
            var factory = new ConnectionFactory { Uri = new Uri(_hostApi) };

            try
            {
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        // Cria uma fila caso nao exista. Persistida em caso de restart do broker 
                        channel.QueueDeclare(queue: _queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

                        var consumer = new EventingBasicConsumer(channel);

                        // add the message receive event
                        consumer.Received += (model, deliveryEventArgs) =>
                        {
                            var body = deliveryEventArgs.Body.ToArray();

                            // convert the message back from byte[] to a string
                            var message = Encoding.UTF8.GetString(body);
                            //RegistraLogService.Log(" Recebido: " + message);

                            // ack the message, ie. confirm that we have processed it
                            // otherwise it will be requeued a bit later
                            channel.BasicAck(deliveryEventArgs.DeliveryTag, false);
                        };

                        // start consuming
                        _ = channel.BasicConsume(consumer, _queueName);

                        // Wait for the reset event and clean up when it triggers
                        resetEvent.WaitOne();
                    }
                }
            }
            catch (Exception ex)
            {
                //RegistraLogService.Log("LerFila: " + ex.Message);
            }
        }
    
    }
}
