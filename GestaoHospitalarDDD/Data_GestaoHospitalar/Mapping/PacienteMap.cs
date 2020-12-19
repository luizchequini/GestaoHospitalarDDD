using Domain_GestaoHospitalar.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data_GestaoHospitalar.Mapping
{
    class PacienteMap : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.HasKey(pk => pk.Id);
            
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(80)")
                .HasColumnName("Nome");
            
            builder.Property(p => p.Email)
                .HasColumnType("varchar(80)")
                .HasColumnName("Email");
            
            builder.Property(p => p.Cpf)
                .HasMaxLength(11)
                .IsFixedLength(true)
                .HasColumnType("varchar(11)");

            builder.Property(p => p.Rg)
               .HasMaxLength(15)
               .IsFixedLength(true)
               .HasColumnType("varchar(15)");

            builder.Property(p => p.RgOrgao)
                .HasColumnType("varchar(10)");

            builder.HasOne(p => p.EstadoPaciente)
                .WithMany(p => p.Paciente)
                .HasForeignKey(p => p.EstadoPacienteId)
                .HasPrincipalKey(para => para.Id);

            builder.ToTable("Pacientes");
        }
    }
}
