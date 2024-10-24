using Services;
using System.Text;

namespace PublisherWinForm
{
    public partial class FPublisher : Form
    {
        public FPublisher()
        {
            InitializeComponent();
        }

        private void btnEnviaMensagem_Click(object sender, EventArgs e)
        {
            var rabbitmqService = new ServciceRabbitMQ();

            for (int i = 1; i <= nQuantidade.Value; i++)
            {
                string strMessage = "";

                if (!string.IsNullOrWhiteSpace(tbPrefixoMensagem.Text))
                    strMessage += tbPrefixoMensagem.Text + "_";

                if (nQuantidade.Value > 1)
                    strMessage += i.ToString() + "_";

                strMessage += Guid.NewGuid().ToString().Substring(0, 8) + "-" + DateTime.Now.ToString();


                lbMensagens.Items.Add(strMessage);

                Task.Run(async () => { await rabbitmqService.AddMessage(strMessage); });
            }


        }

    }
}
