using Microsoft.EntityFrameworkCore;

namespace Data_GestaoHospitalar.ORM
{
    public class GestaoHospitalarDbContext : DbContext
    {
        public GestaoHospitalarDbContext(DbContextOptions<GestaoHospitalarDbContext> options) : base(options)
        {

        }
    }
}
