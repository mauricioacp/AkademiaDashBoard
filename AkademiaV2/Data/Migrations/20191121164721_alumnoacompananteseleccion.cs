using Microsoft.EntityFrameworkCore.Migrations;

namespace AkademiaV2.Data.Migrations
{
    public partial class alumnoacompananteseleccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColaboradoresId",
                table: "Alumnos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Entrevista",
                table: "Alumnos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_ColaboradoresId",
                table: "Alumnos",
                column: "ColaboradoresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alumnos_Colaboradores_ColaboradoresId",
                table: "Alumnos",
                column: "ColaboradoresId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumnos_Colaboradores_ColaboradoresId",
                table: "Alumnos");

            migrationBuilder.DropIndex(
                name: "IX_Alumnos_ColaboradoresId",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "ColaboradoresId",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "Entrevista",
                table: "Alumnos");
        }
    }
}
