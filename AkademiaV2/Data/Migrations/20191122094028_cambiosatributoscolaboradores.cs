using Microsoft.EntityFrameworkCore.Migrations;

namespace AkademiaV2.Data.Migrations
{
    public partial class cambiosatributoscolaboradores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comentarios",
                table: "Colaboradores");

            migrationBuilder.AddColumn<string>(
                name: "CloudCarpetaPrincipal",
                table: "Colaboradores",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CloudCarpetaPrincipal",
                table: "Colaboradores");

            migrationBuilder.AddColumn<string>(
                name: "Comentarios",
                table: "Colaboradores",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
