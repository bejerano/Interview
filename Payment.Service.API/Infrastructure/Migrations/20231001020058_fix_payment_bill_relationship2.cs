using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plooto.Assessment.Payment.API.Infrastructure.Migrations
{
    public partial class fix_payment_bill_relationship2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedOn",
                schema: "billing",
                table: "Payments",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 10, 1, 2, 0, 58, 150, DateTimeKind.Unspecified).AddTicks(2230), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 10, 1, 1, 59, 55, 775, DateTimeKind.Unspecified).AddTicks(8030), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedOn",
                schema: "billing",
                table: "Bills",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 10, 1, 2, 0, 58, 152, DateTimeKind.Unspecified).AddTicks(1370), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 10, 1, 1, 59, 55, 777, DateTimeKind.Unspecified).AddTicks(5044), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedOn",
                schema: "billing",
                table: "Payments",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 10, 1, 1, 59, 55, 775, DateTimeKind.Unspecified).AddTicks(8030), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 10, 1, 2, 0, 58, 150, DateTimeKind.Unspecified).AddTicks(2230), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedOn",
                schema: "billing",
                table: "Bills",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 10, 1, 1, 59, 55, 777, DateTimeKind.Unspecified).AddTicks(5044), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 10, 1, 2, 0, 58, 152, DateTimeKind.Unspecified).AddTicks(1370), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
