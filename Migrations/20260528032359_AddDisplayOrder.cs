using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_EP26.Migrations
{
    /// <inheritdoc />
    public partial class AddDisplayOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Candidates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 1,
                column: "DisplayOrder",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 2,
                column: "DisplayOrder",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 3,
                column: "DisplayOrder",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 4,
                column: "DisplayOrder",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 5,
                column: "DisplayOrder",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 6,
                column: "DisplayOrder",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 7,
                column: "DisplayOrder",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 8,
                column: "DisplayOrder",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 9,
                column: "DisplayOrder",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 10,
                column: "DisplayOrder",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 11,
                column: "DisplayOrder",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 12,
                column: "DisplayOrder",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 13,
                column: "DisplayOrder",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 14,
                column: "DisplayOrder",
                value: 14);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Candidates");
        }
    }
}
