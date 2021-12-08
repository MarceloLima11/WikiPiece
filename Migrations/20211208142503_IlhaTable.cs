using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WikiPiece.Migrations
{
    public partial class IlhaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IlhaId",
                table: "Personagens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ilhas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Regiao = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Clima = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImagemUrl = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilhas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Personagens_IlhaId",
                table: "Personagens",
                column: "IlhaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personagens_Ilhas_IlhaId",
                table: "Personagens",
                column: "IlhaId",
                principalTable: "Ilhas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personagens_Ilhas_IlhaId",
                table: "Personagens");

            migrationBuilder.DropTable(
                name: "Ilhas");

            migrationBuilder.DropIndex(
                name: "IX_Personagens_IlhaId",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "IlhaId",
                table: "Personagens");
        }
    }
}
