using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace back_EP26.Migrations
{
    /// <inheritdoc />
    public partial class AddCandidatesAndVicePresident : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VicePresident",
                table: "Candidates",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Coalition", "Name", "Party", "VicePresident" },
                values: new object[] { null, "Clara Eugenia López Obregón", "Partido Esperanza Democrática", "María Consuelo del Río Mantilla" });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Coalition", "Name", "Party", "VicePresident" },
                values: new object[] { null, "Óscar Mauricio Lizcano Arango", "Coalición F.A.M.I.L.I.A", "Adriana María Ramírez Martínez" });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Coalition", "Name", "Party", "VicePresident" },
                values: new object[] { null, "Raúl Santiago Botero Jaramillo", "Romper el sistema", "Carlos Fernando Cuevas Romero" });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "Coalition", "Name", "Party", "PhotoUrl", "VicePresident" },
                values: new object[,]
                {
                    { 4, null, "Miguel Uribe Londoño", "Partido Demócrata Colombiano", "", "Luisa Fernanda Villegas Araque" },
                    { 5, null, "Sondra Macollins Garvin Pinto", "Sondra Macollins, la abogada de hierro", "", "Leonardo Karam Helo" },
                    { 6, null, "Iván Cepeda Castro", "Movimiento Político Pacto Histórico", "", "Aída Marina Quilcué Vivas" },
                    { 7, null, "Abelardo Gabriel de la Espriella", "Defensores de la patria", "", "José Manuel Restrepo Abondano" },
                    { 8, null, "Claudia Nayibe López Hernández", "Con Claudia imparables", "", "Leonardo Humberto Huerta Gutiérrez" },
                    { 9, null, "Paloma Susana Valencia Laserna", "Partido Centro Democrático", "", "Juan Daniel Oviedo Arango" },
                    { 10, null, "Sergio Fajardo Valderrama", "Partido Dignidad & Compromiso", "", "Edna Cristina del Socorro Bonilla Seba" },
                    { 11, null, "Roy Leonardo Barreras Montealegre", "Partido político La Fuerza", "", "Martha Lucía Zamora Ávila" },
                    { 12, null, "Gustavo Matamoros Camacho", "Partido Ecologista Colombiano", "", "Robinson Alonso Giraldo Mira" },
                    { 13, null, "Luis Gilberto Murillo Urrutia", "Luis Gilberto soy yo", "", "Luz María Zapata Zapata" },
                    { 14, null, "Carlos Eduardo Caicedo Omar", "Caicedo", "", "Nelson Javier Alarcón Suárez" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DropColumn(
                name: "VicePresident",
                table: "Candidates");

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Coalition", "Name", "Party" },
                values: new object[] { "", "Candidato A", "Partido A" });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Coalition", "Name", "Party" },
                values: new object[] { "", "Candidato B", "Partido B" });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Coalition", "Name", "Party" },
                values: new object[] { "", "Candidato C", "Partido C" });
        }
    }
}
