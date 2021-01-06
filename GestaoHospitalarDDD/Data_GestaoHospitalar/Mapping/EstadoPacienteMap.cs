using Domain_GestaoHospitalar.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data_GestaoHospitalar.Mapping
{
    class EstadoPacienteMap : IEntityTypeConfiguration<EstadoPaciente>
    {
        public void Configure(EntityTypeBuilder<EstadoPaciente> builder)
        {
            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.Descricao)
                .HasColumnName("Descricao");

            builder.HasMany(p => p.Paciente);

            builder.ToTable("EstadoPacientes");
        }
    }
}
