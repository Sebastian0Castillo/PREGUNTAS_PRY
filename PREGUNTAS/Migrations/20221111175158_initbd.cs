using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PREGUNTAS.Migrations
{
    public partial class initbd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sessions");

            migrationBuilder.EnsureSchema(
                name: "users");

            migrationBuilder.CreateTable(
                name: "preguntas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion_pregunta = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_preguntas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "security",
                schema: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(80)", nullable: false),
                    login = table.Column<string>(type: "varchar(80)", nullable: false),
                    password = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_security", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Respuestas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion_pregunta = table.Column<string>(type: "varchar(100)", nullable: false),
                    id_pregunta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respuestas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Respuestas_preguntas_id_pregunta",
                        column: x => x.id_pregunta,
                        principalTable: "preguntas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "security",
                schema: "sessions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jti = table.Column<string>(type: "varchar(100)", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_security", x => x.id);
                    table.ForeignKey(
                        name: "FK_security_security_user_id",
                        column: x => x.user_id,
                        principalSchema: "users",
                        principalTable: "security",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_id_pregunta",
                table: "Respuestas",
                column: "id_pregunta");

            migrationBuilder.CreateIndex(
                name: "IX_security_Jti",
                schema: "sessions",
                table: "security",
                column: "Jti",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_security_user_id",
                schema: "sessions",
                table: "security",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Respuestas");

            migrationBuilder.DropTable(
                name: "security",
                schema: "sessions");

            migrationBuilder.DropTable(
                name: "preguntas");

            migrationBuilder.DropTable(
                name: "security",
                schema: "users");
        }
    }
}
