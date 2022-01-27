using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_Pandiani.Migrations
{
    public partial class segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurnoEnum = table.Column<int>(type: "int", nullable: false),
                    Cargo = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Antiguedad = table.Column<int>(type: "int", nullable: false),
                    Sueldo = table.Column<double>(type: "float", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Asistencia",
                columns: table => new
                {
                    AsistenciaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Dia = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistencia", x => x.AsistenciaId);
                    table.ForeignKey(
                        name: "FK_Asistencia_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Habitaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoAcargoId = table.Column<int>(type: "int", nullable: true),
                    IdEmpleado = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Mantenimiento = table.Column<bool>(type: "bit", nullable: false),
                    TipoMantenimiento = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Entrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ocupacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Habitaciones_Empleados_EmpleadoAcargoId",
                        column: x => x.EmpleadoAcargoId,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Telefonos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefonos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telefonos_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asistencia_EmpleadoId",
                table: "Asistencia",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Habitaciones_EmpleadoAcargoId",
                table: "Habitaciones",
                column: "EmpleadoAcargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefonos_EmpleadoId",
                table: "Telefonos",
                column: "EmpleadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asistencia");

            migrationBuilder.DropTable(
                name: "Habitaciones");

            migrationBuilder.DropTable(
                name: "Telefonos");

            migrationBuilder.DropTable(
                name: "Empleados");
        }
    }
}
