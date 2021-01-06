using Microsoft.EntityFrameworkCore.Migrations;

namespace Data_GestaoHospitalar.Migrations
{
    public partial class UpdateBreakingChangeString90 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Pacientes",
                type: "varchar(90)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(80)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "EstadoPacientes",
                type: "varchar(90)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Pacientes",
                type: "varchar(80)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(90)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "EstadoPacientes",
                type: "varchar(30)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(90)",
                oldMaxLength: 100);
        }
    }
}
