using Domain_GestaoHospitalar.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data_GestaoHospitalar.ORM
{
    public class GestaoHospitalarDbContext : DbContext
    {
        public GestaoHospitalarDbContext(DbContextOptions<GestaoHospitalarDbContext> options) : base(options)
        { }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<EstadoPaciente> EstadoPacientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
             * Onde não estiver setado varchar e a propriedade for do tipo string fica valendo varchar(100)
             */
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
            {
                property.Relational().ColumnType = "varchar(100)";
            }

            //modelBuilder.ApplyConfiguration(new EstadoPacienteMap());
            //modelBuilder.ApplyConfiguration(new PacienteMap());
            /*
             * Busca todos os Mapping Fluent API
             */
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GestaoHospitalarDbContext).Assembly);

            /*
             * Remove o delete cascade
             */
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);

        }

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        //{
        //    foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
        //    {
        //        if (entry.State == EntityState.Added)
        //        {
        //            entry.Property("DataCadastro").CurrentValue = DateTime.Now;
        //        }

        //        if (entry.State == EntityState.Modified)
        //        {
        //            entry.Property("DataCadastro").IsModified = false;
        //        }

        //    }
            
        //    return base.SaveChangesAsync(cancellationToken);
        //}
    }
}
