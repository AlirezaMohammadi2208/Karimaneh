using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karimaneh.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EhsanFix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MembersStatus",
                table: "Members",
                newName: "MemberStatus");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "StartDate",
                table: "Loans",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "MemberId",
                table: "Loans",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DueDate",
                table: "Installments",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Loans");

            migrationBuilder.RenameColumn(
                name: "MemberStatus",
                table: "Members",
                newName: "MembersStatus");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Loans",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "Installments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }
    }
}
