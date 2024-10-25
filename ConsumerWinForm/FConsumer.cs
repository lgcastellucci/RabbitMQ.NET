using Services;

namespace ConsumerWinForm
{
    public partial class FConsumer : Form
    {
        private ServciceRabbitMQ _rabbitmqService;
        public FConsumer()
        {
            InitializeComponent();
            _rabbitmqService = new ServciceRabbitMQ();
            _rabbitmqService.MessageReceived += RabbitmqService_MessageReceived;
            _rabbitmqService.MessageReceivedLog += RabbitmqService_MessageReceivedLog;
        }

        private void btnConectarConsumer_Click(object sender, EventArgs e)
        {

            Task.Run(async () => { await _rabbitmqService.StartConsumer(Application.ProductName); });
            lbStatus.Text = "Consumer Iniciado";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _rabbitmqService.StopConsumer();
            lbStatus.Text = "Consumer Parado";
        }
        private void RabbitmqService_MessageReceived(object sender, string message)
        {
            // Atualiza o lbMensagens.Text na thread da UI
            if (lbMensagens.InvokeRequired)
            {
                lbMensagens.Invoke(new Action(() => lbMensagens.Items.Add(message)));
            }
            else
            {
                lbMensagens.Items.Add(message); 
            }
        }

        private void RabbitmqService_MessageReceivedLog(object sender, string message)
        {
            // Atualiza o lbMensagensLogs.Text na thread da UI
            if (lbMensagensLogs.InvokeRequired)
            {
                lbMensagensLogs.Invoke(new Action(() => lbMensagensLogs.Items.Add(message)));
            }
            else
            {
                lbMensagensLogs.Items.Add(message); 
            }
        }

    }
}
