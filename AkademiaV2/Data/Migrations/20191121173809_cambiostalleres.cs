using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AkademiaV2.Data.Migrations
{
    public partial class cambiostalleres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comentarios",
                table: "Talleres");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "Talleres");

            migrationBuilder.AddColumn<string>(
                name: "CarpetaPrincipal",
                table: "Talleres",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaTaller",
                table: "Talleres",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Entrevista",
                table: "Colaboradores",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarpetaPrincipal",
                table: "Talleres");

            migrationBuilder.DropColumn(
                name: "FechaTaller",
                table: "Talleres");

            migrationBuilder.DropColumn(
                name: "Entrevista",
                table: "Colaboradores");

            migrationBuilder.AddColumn<string>(
                name: "Comentarios",
                table: "Talleres",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Talleres",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
