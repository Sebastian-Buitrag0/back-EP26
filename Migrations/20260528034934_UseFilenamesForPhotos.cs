using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_EP26.Migrations
{
    /// <inheritdoc />
    public partial class UseFilenamesForPhotos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhotoUrl",
                value: "clara-lopez.jpg");

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 2,
                column: "PhotoUrl",
                value: "mauricio-lizcano.jpg");

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 3,
                column: "PhotoUrl",
                value: "santiago-botero.jpg");

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 4,
                column: "PhotoUrl",
                value: "miguel-uribe.jpg");

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 5,
                column: "PhotoUrl",
                value: "sandra-macollins.jpg");

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 6,
                column: "PhotoUrl",
                value: "cepeda.jpg");

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 7,
                column: "PhotoUrl",
                value: "abelardo.jpg");

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 8,
                column: "PhotoUrl",
                value: "claudia.jpg");

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 9,
                column: "PhotoUrl",
                value: "paloma.jpg");

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 10,
                column: "PhotoUrl",
                value: "fajardo.webp");

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 11,
                column: "PhotoUrl",
                value: "roy-barreras.jpg");

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 12,
                column: "PhotoUrl",
                value: "gustavo-matamoros.jpg");

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 13,
                column: "PhotoUrl",
                value: "gilberto-murillo.avif");

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 14,
                column: "PhotoUrl",
                value: "carlos-caicedo.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhotoUrl",
                value: "/candidatos/clara-lopez.jpg");

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 2,
                column: "PhotoUrl",
                value: "/candidatos/mauricio-lizcano.jpg");

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 3,
                column: "PhotoUrl",
                value: "/candidatos/santiago-botero.jpg");

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 4,
                column: "PhotoUrl",
                value: "/candidatos/miguel-uribe.jpg");

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 5,
                column: "PhotoUrl",
                value: "/candidatos/sandra-macollins.jpg");

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 6,
                column: "PhotoUrl",
                value: "/candidatos/cepeda.jpg");

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 7,
                column: "PhotoUrl",
                value: "/candidatos/abelardo.jpg");

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 8,
                column: "PhotoUrl",
                value: "/candidatos/claudia.jpg");

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 9,
                column: "PhotoUrl",
                value: "/candidatos/paloma.jpg");

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 10,
                column: "PhotoUrl",
                value: "/candidatos/fajardo.webp");

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 11,
                column: "PhotoUrl",
                value: "/candidatos/roy-barreras.jpg");

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 12,
                column: "PhotoUrl",
                value: "/candidatos/gustavo-matamoros.jpg");

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 13,
                column: "PhotoUrl",
                value: "/candidatos/gilberto-murillo.avif");

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 14,
                column: "PhotoUrl",
                value: "/candidatos/carlos-caicedo.jpg");
        }
    }
}
