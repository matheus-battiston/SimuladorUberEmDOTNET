using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeLevaAi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Passageiros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascimento = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Cpf = table.Column<string>(type: "TEXT", nullable: false),
                    SaldoEmConta = table.Column<float>(type: "REAL", nullable: false),
                    QuantidadeAvaliacoes = table.Column<int>(type: "INTEGER", nullable: false),
                    SomaDasNotas = table.Column<int>(type: "INTEGER", nullable: false),
                    MediaDasAvaliacoes = table.Column<double>(type: "REAL", nullable: false),
                    NumeroDeCorridas = table.Column<int>(type: "INTEGER", nullable: false),
                    Disponivel = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passageiros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Placa = table.Column<string>(type: "TEXT", nullable: false),
                    Modelo = table.Column<string>(type: "TEXT", nullable: false),
                    Cor = table.Column<string>(type: "TEXT", nullable: false),
                    FotoUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Categoria = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motoristas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Saldo = table.Column<double>(type: "REAL", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CPF = table.Column<string>(type: "TEXT", nullable: false),
                    HabilitacaoNumero = table.Column<string>(type: "TEXT", nullable: false),
                    HabilitacaoDataVencimento = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    HabilitacaoCategoria = table.Column<int>(type: "INTEGER", nullable: false),
                    Disponivel = table.Column<bool>(type: "INTEGER", nullable: false),
                    SomaDasNotas = table.Column<int>(type: "INTEGER", nullable: false),
                    MediaDasNotas = table.Column<double>(type: "REAL", nullable: false),
                    NumeroDeCorridas = table.Column<int>(type: "INTEGER", nullable: false),
                    QuantidadeDeAvaliacoes = table.Column<int>(type: "INTEGER", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motoristas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motoristas_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Corridas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    LatitudeInicio = table.Column<double>(type: "REAL", nullable: false),
                    LongitudeInicio = table.Column<double>(type: "REAL", nullable: false),
                    LatitudeFinal = table.Column<double>(type: "REAL", nullable: false),
                    LongitudeFinal = table.Column<double>(type: "REAL", nullable: false),
                    HorarioInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HorarioChegada = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorEstimado = table.Column<double>(type: "REAL", nullable: false),
                    ValorTotal = table.Column<double>(type: "REAL", nullable: false),
                    NotaMotorista = table.Column<int>(type: "INTEGER", nullable: false),
                    NotaPassageiro = table.Column<int>(type: "INTEGER", nullable: false),
                    PassageiroId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MotoristaId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corridas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Corridas_Motoristas_PassageiroId",
                        column: x => x.PassageiroId,
                        principalTable: "Motoristas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Corridas_Passageiros_PassageiroId",
                        column: x => x.PassageiroId,
                        principalTable: "Passageiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Corridas_PassageiroId",
                table: "Corridas",
                column: "PassageiroId");

            migrationBuilder.CreateIndex(
                name: "IX_Motoristas_VeiculoId",
                table: "Motoristas",
                column: "VeiculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Corridas");

            migrationBuilder.DropTable(
                name: "Motoristas");

            migrationBuilder.DropTable(
                name: "Passageiros");

            migrationBuilder.DropTable(
                name: "Veiculos");
        }
    }
}
