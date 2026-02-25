using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karimaneh.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Members",
                newName: "FullName");

            migrationBuilder.AddColumn<bool>(
                name: "MembersStatus",
                table: "Members",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MembersStatus",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Members",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
