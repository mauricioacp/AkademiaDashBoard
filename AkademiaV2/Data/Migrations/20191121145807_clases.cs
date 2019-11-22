using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AkademiaV2.Data.Migrations
{
    public partial class clases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Akademia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Edicion = table.Column<int>(nullable: false),
                    Ciudad = table.Column<string>(maxLength: 40, nullable: false),
                    Direccion = table.Column<string>(maxLength: 250, nullable: false),
                    Imagen = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Akademia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Talleres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Imagen = table.Column<string>(nullable: true),
                    Karrusel = table.Column<string>(nullable: true),
                    Edicion = table.Column<int>(nullable: false),
                    Evaluaciones = table.Column<string>(nullable: true),
                    Comentarios = table.Column<string>(nullable: true),
                    AkademiaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talleres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Talleres_Akademia_AkademiaId",
                        column: x => x.AkademiaId,
                        principalTable: "Akademia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlumnosTalleres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TalleresId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnosTalleres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlumnosTalleres_Talleres_TalleresId",
                        column: x => x.TalleresId,
                        principalTable: "Talleres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ColaboradoresTalleres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TalleresId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColaboradoresTalleres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColaboradoresTalleres_Talleres_TalleresId",
                        column: x => x.TalleresId,
                        principalTable: "Talleres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Apellidos = table.Column<string>(nullable: false),
                    Imagen = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: false),
                    CartaMotivacional = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Comentarios = table.Column<string>(nullable: true),
                    Edicion = table.Column<int>(nullable: false),
                    AlumnosTalleresId = table.Column<int>(nullable: true),
                    AkademiaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alumnos_Akademia_AkademiaId",
                        column: x => x.AkademiaId,
                        principalTable: "Akademia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alumnos_AlumnosTalleres_AlumnosTalleresId",
                        column: x => x.AlumnosTalleresId,
                        principalTable: "AlumnosTalleres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Apellidos = table.Column<string>(nullable: false),
                    Imagen = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: false),
                    CartaMotivacional = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Comentarios = table.Column<string>(nullable: true),
                    Edicion = table.Column<int>(nullable: false),
                    ColaboradoresTalleresId = table.Column<int>(nullable: true),
                    AkademiaId = table.Column<int>(nullable: true),
                    TipoColaborador = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colaboradores_Akademia_AkademiaId",
                        column: x => x.AkademiaId,
                        principalTable: "Akademia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Colaboradores_ColaboradoresTalleres_ColaboradoresTalleresId",
                        column: x => x.ColaboradoresTalleresId,
                        principalTable: "ColaboradoresTalleres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sesiones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Evaluacion = table.Column<string>(nullable: true),
                    Comentario = table.Column<string>(nullable: true),
                    Edicion = table.Column<int>(nullable: false),
                    ColaboradorId = table.Column<int>(nullable: false),
                    AlumnoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesiones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sesiones_Alumnos_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Alumnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sesiones_Colaboradores_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_AkademiaId",
                table: "Alumnos",
                column: "AkademiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_AlumnosTalleresId",
                table: "Alumnos",
                column: "AlumnosTalleresId");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnosTalleres_TalleresId",
                table: "AlumnosTalleres",
                column: "TalleresId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_AkademiaId",
                table: "Colaboradores",
                column: "AkademiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_ColaboradoresTalleresId",
                table: "Colaboradores",
                column: "ColaboradoresTalleresId");

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradoresTalleres_TalleresId",
                table: "ColaboradoresTalleres",
                column: "TalleresId");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_AlumnoId",
                table: "Sesiones",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_ColaboradorId",
                table: "Sesiones",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Talleres_AkademiaId",
                table: "Talleres",
                column: "AkademiaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sesiones");

            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.DropTable(
                name: "Colaboradores");

            migrationBuilder.DropTable(
                name: "AlumnosTalleres");

            migrationBuilder.DropTable(
                name: "ColaboradoresTalleres");

            migrationBuilder.DropTable(
                name: "Talleres");

            migrationBuilder.DropTable(
                name: "Akademia");
        }
    }
}
