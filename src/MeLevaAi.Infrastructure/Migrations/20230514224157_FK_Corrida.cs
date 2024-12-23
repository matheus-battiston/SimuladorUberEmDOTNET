using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeLevaAi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FK_Corrida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Corridas_Motoristas_PassageiroId",
                table: "Corridas");

            migrationBuilder.CreateIndex(
                name: "IX_Corridas_MotoristaId",
                table: "Corridas",
                column: "MotoristaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Corridas_Motoristas_MotoristaId",
                table: "Corridas",
                column: "MotoristaId",
                principalTable: "Motoristas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Corridas_Motoristas_MotoristaId",
                table: "Corridas");

            migrationBuilder.DropIndex(
                name: "IX_Corridas_MotoristaId",
                table: "Corridas");

            migrationBuilder.AddForeignKey(
                name: "FK_Corridas_Motoristas_PassageiroId",
                table: "Corridas",
                column: "PassageiroId",
                principalTable: "Motoristas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
