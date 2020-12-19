using Microsoft.EntityFrameworkCore.Migrations;

namespace Data_GestaoHospitalar.Migrations
{
    public partial class AddMappingFluentApiPacienteEstadoPacienteAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_EstadoPacientes_EstadoPacienteId",
                table: "Pacientes");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_EstadoPacientes_EstadoPacienteId",
                table: "Pacientes",
                column: "EstadoPacienteId",
                principalTable: "EstadoPacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_EstadoPacientes_EstadoPacienteId",
                table: "Pacientes");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_EstadoPacientes_EstadoPacienteId",
                table: "Pacientes",
                column: "EstadoPacienteId",
                principalTable: "EstadoPacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
