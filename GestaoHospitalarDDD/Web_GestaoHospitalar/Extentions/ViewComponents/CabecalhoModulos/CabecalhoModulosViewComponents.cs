using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web_GestaoHospitalar.Extentions.ViewComponents.Helpers;

namespace Web_GestaoHospitalar.Extentions.ViewComponents.CabecalhoModulos
{
    [ViewComponent(Name = "CabecalhoModulos")]
    public class CabecalhoModulosViewComponents : ViewComponent
    {
        public CabecalhoModulosViewComponents()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync(string titulo, string subtitulo)
        {
            var modulo = new Modulo()
            {
                Titulo = titulo,
                SubTitulo = subtitulo
            };

            return View(modulo);
        }
    }
}
