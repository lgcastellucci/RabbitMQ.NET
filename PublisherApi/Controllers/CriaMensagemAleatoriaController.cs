using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services;

namespace PublisherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CriaMensagemAleatoriaController : ControllerBase
    {
        private readonly ILogger<CriaMensagemAleatoriaController> _logger;

        public CriaMensagemAleatoriaController(ILogger<CriaMensagemAleatoriaController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "CriaMensagemAleatoria")]
        public LogRequest Get()
        {
            var retorno = new LogRequest();
            retorno.DataInicio = DateTime.Now;

            var msg = new Mensagem { Data = DateTime.Now, Conteudo = Guid.NewGuid().ToString() };
            string strMsg = JsonConvert.SerializeObject(msg);

            retorno.Conteudo = strMsg;

            var rabbitmqService = new ServciceRabbitMQ();
            Task.Run(async () => { await rabbitmqService.AddMessage(strMsg); });

            retorno.DataFim = DateTime.Now;

            return retorno;


        }
    }
}
