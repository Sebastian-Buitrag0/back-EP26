using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_EP26.Migrations
{
    /// <inheritdoc />
    public partial class AddIsHonorary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHonorary",
                table: "Votes",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHonorary",
                table: "Votes");
        }
    }
}
