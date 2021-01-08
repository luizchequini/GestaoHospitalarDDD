using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissLog;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        public IActionResult Index()
        {
            var usuario = HttpContext.User.Identity.Name;
            //var msgLogger = $"Exception try: {usuario}: UM ERRO PROPOSITAL OCORREU.\nContate o administrador!";

            //_logger.Trace($"O usuario {usuario} realizou este procedimento");

            //try
            //{
            //    throw new Exception(msgLogger);
            //}
            //catch (Exception e)
            //{
            //    _logger.Error($"{e} = Exception catch: {usuario}");
            //}

            //_logger.Debug("Hello world from .NET Core 3.x!");

            throw new Exception($"FORÇANDO ERRO SEM TRATAMENTO: {usuario}!");

            return View();
        }
    }
}
