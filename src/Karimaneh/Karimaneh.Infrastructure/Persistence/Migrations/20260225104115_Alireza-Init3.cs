using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karimaneh.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AlirezaInit3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber_Value",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber_Value",
                table: "Members");
        }
    }
}
