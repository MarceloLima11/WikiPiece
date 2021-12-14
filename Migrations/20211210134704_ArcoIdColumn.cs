using Microsoft.EntityFrameworkCore.Migrations;

namespace WikiPiece.Migrations
{
    public partial class ArcoIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personagens_Ilhas_IlhaId",
                table: "Personagens");

            migrationBuilder.DropIndex(
                name: "IX_Personagens_IlhaId",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "IlhaId",
                table: "Personagens");

            migrationBuilder.AddColumn<int>(
                name: "ArcoId",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImagemUrl",
                table: "Arcos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Personagens_ArcoId",
                table: "Personagens",
                column: "ArcoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personagens_Arcos_ArcoId",
                table: "Personagens",
                column: "ArcoId",
                principalTable: "Arcos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personagens_Arcos_ArcoId",
                table: "Personagens");

            migrationBuilder.DropIndex(
                name: "IX_Personagens_ArcoId",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "ArcoId",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "ImagemUrl",
                table: "Arcos");

            migrationBuilder.AddColumn<int>(
                name: "IlhaId",
                table: "Personagens",
                type: "int",
                nullable: true);

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
    }
}
