using Data_GestaoHospitalar.ORM;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Web_GestaoHospitalar.Extentions.ViewComponents.Helpers
{
    public static class Util
    {
        public static int TotReg(GestaoHospitalarDbContext ctx)
        {
            return (from pac in ctx.Pacientes.AsNoTracking() select pac ).Count();
        }

        public static decimal GetNumRegEstado(GestaoHospitalarDbContext ctx, string estado)
        {
            return ctx.Pacientes
                    .Include(x => x.EstadoPaciente)
                    .AsNoTracking()
                    .Count(x => x.EstadoPaciente.Descricao.Contains(estado));
        }
    }
}
