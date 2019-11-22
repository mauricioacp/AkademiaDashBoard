using Microsoft.EntityFrameworkCore.Migrations;

namespace AkademiaV2.Data.Migrations
{
    public partial class registrosactividad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusquedaAcompañantes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlumnosId = table.Column<int>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    RutaDrive = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusquedaAcompañantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusquedaAcompañantes_Alumnos_AlumnosId",
                        column: x => x.AlumnosId,
                        principalTable: "Alumnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusquedaAlumnos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlumnosId = table.Column<int>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    RutaDrive = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusquedaAlumnos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusquedaAlumnos_Alumnos_AlumnosId",
                        column: x => x.AlumnosId,
                        principalTable: "Alumnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusquedaFacilitadores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColaboradoresId = table.Column<int>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    RutaDrive = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusquedaFacilitadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusquedaFacilitadores_Colaboradores_ColaboradoresId",
                        column: x => x.ColaboradoresId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegistroActividades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColaboradoresId = table.Column<int>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroActividades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistroActividades_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusquedaAcompañantes_AlumnosId",
                table: "BusquedaAcompañantes",
                column: "AlumnosId");

            migrationBuilder.CreateIndex(
                name: "IX_BusquedaAlumnos_AlumnosId",
                table: "BusquedaAlumnos",
                column: "AlumnosId");

            migrationBuilder.CreateIndex(
                name: "IX_BusquedaFacilitadores_ColaboradoresId",
                table: "BusquedaFacilitadores",
                column: "ColaboradoresId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroActividades_AppUserId",
                table: "RegistroActividades",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusquedaAcompañantes");

            migrationBuilder.DropTable(
                name: "BusquedaAlumnos");

            migrationBuilder.DropTable(
                name: "BusquedaFacilitadores");

            migrationBuilder.DropTable(
                name: "RegistroActividades");
        }
    }
}
