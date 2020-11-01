using Data_GestaoHospitalar.ORM;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web_GestaoHospitalar.Extentions.ViewComponents.Helpers;

namespace Web_GestaoHospitalar.Extentions.ViewComponents.EstadoPaciente
{
    [ViewComponent(Name = "EstadoCritico")]
    public class EstadoCriticoViewComponents : ViewComponent
    {
        private readonly GestaoHospitalarDbContext _context;
        public EstadoCriticoViewComponents(GestaoHospitalarDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int totalGeral = Util.TotReg(_context);
            decimal totalEstado = Util.GetNumRegEstado(_context, "Crítico");

            decimal progress = totalEstado * 100 / totalGeral;
            var prctl = progress.ToString("F1");

            var model = new ContadorEstadoPaciente()
            {
                Titulo = "Estado Critico",
                Parcial = (int)totalEstado,
                Percentual = prctl,
                ClassContainer = "panel panel-warning tile panelClose panelRefresh",
                IconeLg = "l-ecommerce-graph3",
                IconeSm = "fa fa-chevron-circle-right s20 mr5 pull-left",
                Progress = progress
            };

            return View(model);
        }
    }
}
