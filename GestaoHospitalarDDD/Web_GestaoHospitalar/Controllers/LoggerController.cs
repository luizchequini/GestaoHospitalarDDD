using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web_GestaoHospitalar.Controllers
{
    public class LoggerController : Controller
    {
        private readonly ILogger<LoggerController> _logger;

        public LoggerController(ILogger<LoggerController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var msgLogger = "TESTANDO EXIBIÇÃO DE LOGGER";

            _logger.Log(LogLevel.Critical, msgLogger);
            _logger.Log(LogLevel.Warning, msgLogger);
            _logger.Log(LogLevel.Trace, msgLogger);
            _logger.LogError(msgLogger);

            try
            {
                throw new Exception("UMA EXCEÇÃO GERADA PARA DE TESTE DE AUDITORIA");
            }
            catch (Exception e)
            {

                _logger.LogError(e.Message);
            }

            ViewData["msgLogger"] = msgLogger;

            return View();
        }
    }
}
