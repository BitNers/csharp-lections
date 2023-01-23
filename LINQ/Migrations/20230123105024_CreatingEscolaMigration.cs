using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LINQ.Migrations
{
    /// <inheritdoc />
    public partial class CreatingEscolaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.AlunoId);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    MateriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.MateriaId);
                });

            migrationBuilder.CreateTable(
                name: "AlunoModelMateriaModel",
                columns: table => new
                {
                    AlunosAlunoId = table.Column<int>(type: "int", nullable: false),
                    MateriasMateriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoModelMateriaModel", x => new { x.AlunosAlunoId, x.MateriasMateriaId });
                    table.ForeignKey(
                        name: "FK_AlunoModelMateriaModel_Aluno_AlunosAlunoId",
                        column: x => x.AlunosAlunoId,
                        principalTable: "Aluno",
                        principalColumn: "AlunoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoModelMateriaModel_Materias_MateriasMateriaId",
                        column: x => x.MateriasMateriaId,
                        principalTable: "Materias",
                        principalColumn: "MateriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoModelMateriaModel_MateriasMateriaId",
                table: "AlunoModelMateriaModel",
                column: "MateriasMateriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoModelMateriaModel");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Materias");
        }
    }
}
