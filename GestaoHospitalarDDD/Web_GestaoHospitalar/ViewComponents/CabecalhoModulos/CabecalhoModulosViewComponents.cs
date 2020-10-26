using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web_GestaoHospitalar.ViewComponents.Helpers;

namespace Web_GestaoHospitalar.ViewComponents.CabecalhoModulos
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
