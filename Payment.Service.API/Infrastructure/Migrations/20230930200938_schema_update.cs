using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plooto.Assessment.Payment.API.Infrastructure.Migrations
{
    public partial class schema_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedOn",
                schema: "billing",
                table: "Payments",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 9, 30, 20, 9, 38, 683, DateTimeKind.Unspecified).AddTicks(5316), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 9, 28, 22, 4, 47, 395, DateTimeKind.Unspecified).AddTicks(9057), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "Identifier",
                schema: "billing",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedOn",
                schema: "billing",
                table: "Bills",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 9, 30, 20, 9, 38, 687, DateTimeKind.Unspecified).AddTicks(4819), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 9, 28, 22, 4, 47, 405, DateTimeKind.Unspecified).AddTicks(978), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identifier",
                schema: "billing",
                table: "Payments");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedOn",
                schema: "billing",
                table: "Payments",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 9, 28, 22, 4, 47, 395, DateTimeKind.Unspecified).AddTicks(9057), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 9, 30, 20, 9, 38, 683, DateTimeKind.Unspecified).AddTicks(5316), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedOn",
                schema: "billing",
                table: "Bills",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 9, 28, 22, 4, 47, 405, DateTimeKind.Unspecified).AddTicks(978), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 9, 30, 20, 9, 38, 687, DateTimeKind.Unspecified).AddTicks(4819), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
