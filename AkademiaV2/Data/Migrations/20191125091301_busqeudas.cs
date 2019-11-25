using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AkademiaV2.Data.Migrations
{
    public partial class busqeudas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusquedaAcompañantes_Alumnos_AlumnosId",
                table: "BusquedaAcompañantes");

            migrationBuilder.DropIndex(
                name: "IX_BusquedaAcompañantes_AlumnosId",
                table: "BusquedaAcompañantes");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "Sesiones");

            migrationBuilder.DropColumn(
                name: "AlumnosId",
                table: "BusquedaAcompañantes");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaSesion",
                table: "Sesiones",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ColaboradoresId",
                table: "BusquedaAcompañantes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusquedaAcompañantes_ColaboradoresId",
                table: "BusquedaAcompañantes",
                column: "ColaboradoresId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusquedaAcompañantes_Colaboradores_ColaboradoresId",
                table: "BusquedaAcompañantes",
                column: "ColaboradoresId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusquedaAcompañantes_Colaboradores_ColaboradoresId",
                table: "BusquedaAcompañantes");

            migrationBuilder.DropIndex(
                name: "IX_BusquedaAcompañantes_ColaboradoresId",
                table: "BusquedaAcompañantes");

            migrationBuilder.DropColumn(
                name: "FechaSesion",
                table: "Sesiones");

            migrationBuilder.DropColumn(
                name: "ColaboradoresId",
                table: "BusquedaAcompañantes");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Sesiones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "AlumnosId",
                table: "BusquedaAcompañantes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusquedaAcompañantes_AlumnosId",
                table: "BusquedaAcompañantes",
                column: "AlumnosId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusquedaAcompañantes_Alumnos_AlumnosId",
                table: "BusquedaAcompañantes",
                column: "AlumnosId",
                principalTable: "Alumnos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
