using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jcf.QuinzePontos.Infraestrutura.Migrations
{
    public partial class AtualizacaoEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Local",
                table: "ResultadosLotofacils",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "EstadosPremiados",
                keyColumn: "Longitude",
                keyValue: null,
                column: "Longitude",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Longitude",
                table: "EstadosPremiados",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "EstadosPremiados",
                keyColumn: "Latitude",
                keyValue: null,
                column: "Latitude",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Latitude",
                table: "EstadosPremiados",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "CidadesPremiadas",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "CidadesPremiadas",
                keyColumn: "Longitude",
                keyValue: null,
                column: "Longitude",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Longitude",
                table: "CidadesPremiadas",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "CidadesPremiadas",
                keyColumn: "Latitude",
                keyValue: null,
                column: "Latitude",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Latitude",
                table: "CidadesPremiadas",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Local",
                table: "ResultadosLotofacils");

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "EstadosPremiados",
                type: "double",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "EstadosPremiados",
                type: "double",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "CidadesPremiadas",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "CidadesPremiadas",
                type: "double",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "CidadesPremiadas",
                type: "double",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30)
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
