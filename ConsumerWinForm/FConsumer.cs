using Services;
using System.ComponentModel;

namespace ConsumerWinForm
{
    public partial class FConsumer : Form
    {
        public FConsumer()
        {
            InitializeComponent();
        }

        private void btnConectarConsumer_Click(object sender, EventArgs e)
        {
            var rabbitmqService = new ServciceRabbitMQ();

            Task.Run(async () => { await rabbitmqService.StartConsumer(); });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var worker = new BackgroundWorker()
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lbMensagens.Items.Add(Guid.NewGuid().ToString().Substring(0, 8) + "-" + DateTime.Now.ToString());
        }
    }
}
