#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace Jcf.QuinzePontos.Infraestrutura.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Concursos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    DataRealizacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Dezena1 = table.Column<int>(type: "int", nullable: false),
                    Dezena2 = table.Column<int>(type: "int", nullable: false),
                    Dezena3 = table.Column<int>(type: "int", nullable: false),
                    Dezena4 = table.Column<int>(type: "int", nullable: false),
                    Dezena5 = table.Column<int>(type: "int", nullable: false),
                    Dezena6 = table.Column<int>(type: "int", nullable: false),
                    Dezena7 = table.Column<int>(type: "int", nullable: false),
                    Dezena8 = table.Column<int>(type: "int", nullable: false),
                    Dezena9 = table.Column<int>(type: "int", nullable: false),
                    Dezena10 = table.Column<int>(type: "int", nullable: false),
                    Dezena11 = table.Column<int>(type: "int", nullable: false),
                    Dezena12 = table.Column<int>(type: "int", nullable: false),
                    Dezena13 = table.Column<int>(type: "int", nullable: false),
                    Dezena14 = table.Column<int>(type: "int", nullable: false),
                    Dezena15 = table.Column<int>(type: "int", nullable: false),
                    ValorAposta = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concursos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ResultadosLotofacils",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ConcursoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Acumulou = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    AcumuladaProxConcurso = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataProxConcurso = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ProxConcurso = table.Column<int>(type: "int", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultadosLotofacils", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultadosLotofacils_Concursos_ConcursoId",
                        column: x => x.ConcursoId,
                        principalTable: "Concursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EstadosPremiados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Uf = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Vencedores = table.Column<int>(type: "int", nullable: true),
                    Latitude = table.Column<double>(type: "double", nullable: true),
                    Longitude = table.Column<double>(type: "double", nullable: true),
                    ResultadoLotofacilId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosPremiados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstadosPremiados_ResultadosLotofacils_ResultadoLotofacilId",
                        column: x => x.ResultadoLotofacilId,
                        principalTable: "ResultadosLotofacils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Premiacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PremiacaoAcerto = table.Column<int>(type: "int", nullable: false),
                    Vencedores = table.Column<int>(type: "int", nullable: false),
                    Premio = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ResultadoLotofacilId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Premiacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Premiacoes_ResultadosLotofacils_ResultadoLotofacilId",
                        column: x => x.ResultadoLotofacilId,
                        principalTable: "ResultadosLotofacils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CidadesPremiadas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EstadoPremiadoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Vencedores = table.Column<int>(type: "int", nullable: true),
                    Latitude = table.Column<double>(type: "double", nullable: true),
                    Longitude = table.Column<double>(type: "double", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CidadesPremiadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CidadesPremiadas_EstadosPremiados_EstadoPremiadoId",
                        column: x => x.EstadoPremiadoId,
                        principalTable: "EstadosPremiados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CidadesPremiadas_EstadoPremiadoId",
                table: "CidadesPremiadas",
                column: "EstadoPremiadoId");

            migrationBuilder.CreateIndex(
                name: "IX_EstadosPremiados_ResultadoLotofacilId",
                table: "EstadosPremiados",
                column: "ResultadoLotofacilId");

            migrationBuilder.CreateIndex(
                name: "IX_Premiacoes_ResultadoLotofacilId",
                table: "Premiacoes",
                column: "ResultadoLotofacilId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultadosLotofacils_ConcursoId",
                table: "ResultadosLotofacils",
                column: "ConcursoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CidadesPremiadas");

            migrationBuilder.DropTable(
                name: "Premiacoes");

            migrationBuilder.DropTable(
                name: "EstadosPremiados");

            migrationBuilder.DropTable(
                name: "ResultadosLotofacils");

            migrationBuilder.DropTable(
                name: "Concursos");
        }
    }
}
