using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissLog;
using Microsoft.AspNetCore.Mvc;

namespace Web_GestaoHospitalar.Controllers
{
    public class LoggerController : Controller
    {
        private readonly ILogger _logger;

        public LoggerController(ILogger logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var msgLogger = "ATENÇÃO: UM ERRO PROPOSITAL OCORREU.\nContate o administrador!";

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                _logger.Trace($"O usuario {HttpContext.User.Identity.Name} realizou este procedimento");
            }
            else
            {
                _logger.Trace("Usuário sem login realizou este procedimento de erro.");
            }

            try
            {
                throw new Exception(msgLogger);
            }
            catch (Exception e)
            {
                _logger.Error($"{e} = {HttpContext.User.Identity.Name}");
            }

            _logger.Debug("Hello world from .NET Core 3.x!");

            return View();
        }
    }
}
