using Domain_GestaoHospitalar.Models;
using Microsoft.EntityFrameworkCore;

namespace Data_GestaoHospitalar.ORM
{
    public class GestaoHospitalarDbContext : DbContext
    {
        public GestaoHospitalarDbContext(DbContextOptions<GestaoHospitalarDbContext> options) : base(options)
        { }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<EstadoPaciente> EstadoPacientes { get; set; }
    }
}
