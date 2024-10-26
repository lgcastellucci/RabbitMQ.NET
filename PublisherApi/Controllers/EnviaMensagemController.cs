using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services;

namespace PublisherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnviaMensagemController : ControllerBase
    {
        private readonly ILogger<EnviaMensagemController> _logger;

        public EnviaMensagemController(ILogger<EnviaMensagemController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "EnviaMensagemController")]
        public LogRequest Post(string mensagem)
        {
            var retorno = new LogRequest();
            retorno.DataInicio = DateTime.Now;

            var msg = new Mensagem { Data = DateTime.Now, Conteudo = mensagem };
            string strMsg = JsonConvert.SerializeObject(msg);

            retorno.Conteudo = strMsg;

            var rabbitmqService = new ServciceRabbitMQ();
            Task.Run(async () => { await rabbitmqService.AddMessage(strMsg); });

            retorno.DataFim = DateTime.Now;

            return retorno;
        }
    }
}
