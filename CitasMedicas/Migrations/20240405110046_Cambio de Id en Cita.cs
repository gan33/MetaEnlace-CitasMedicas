using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitasMedicas.Migrations
{
    /// <inheritdoc />
    public partial class CambiodeIdenCita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicoPaciente_Medicos_MedicosId",
                table: "MedicoPaciente");

            migrationBuilder.RenameColumn(
                name: "CitaId",
                table: "Citas",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "NumColegiado",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaHora",
                table: "Citas",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicoPaciente_Medicos_MedicosId",
                table: "MedicoPaciente",
                column: "MedicosId",
                principalTable: "Medicos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicoPaciente_Medicos_MedicosId",
                table: "MedicoPaciente");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Citas",
                newName: "CitaId");

            migrationBuilder.AlterColumn<string>(
                name: "NumColegiado",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaHora",
                table: "Citas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicoPaciente_Medicos_MedicosId",
                table: "MedicoPaciente",
                column: "MedicosId",
                principalTable: "Medicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
