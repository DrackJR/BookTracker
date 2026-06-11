using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookTracker.Migrations
{
    /// <inheritdoc />
    public partial class avataerUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Avatar",
                table: "AuthUsers",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "AuthUsers");
        }
    }
}
