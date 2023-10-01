using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plooto.Assessment.Payment.API.Infrastructure.Migrations
{
    public partial class fix_payment_bill_relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Bills_BillId1",
                schema: "billing",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_BillId1",
                schema: "billing",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "BillId1",
                schema: "billing",
                table: "Payments");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedOn",
                schema: "billing",
                table: "Payments",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 10, 1, 1, 59, 55, 775, DateTimeKind.Unspecified).AddTicks(8030), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 9, 30, 22, 35, 48, 187, DateTimeKind.Unspecified).AddTicks(7255), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedOn",
                schema: "billing",
                table: "Bills",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 10, 1, 1, 59, 55, 777, DateTimeKind.Unspecified).AddTicks(5044), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 9, 30, 22, 35, 48, 190, DateTimeKind.Unspecified).AddTicks(3569), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedOn",
                schema: "billing",
                table: "Payments",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 9, 30, 22, 35, 48, 187, DateTimeKind.Unspecified).AddTicks(7255), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 10, 1, 1, 59, 55, 775, DateTimeKind.Unspecified).AddTicks(8030), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "BillId1",
                schema: "billing",
                table: "Payments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedOn",
                schema: "billing",
                table: "Bills",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 9, 30, 22, 35, 48, 190, DateTimeKind.Unspecified).AddTicks(3569), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 10, 1, 1, 59, 55, 777, DateTimeKind.Unspecified).AddTicks(5044), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BillId1",
                schema: "billing",
                table: "Payments",
                column: "BillId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Bills_BillId1",
                schema: "billing",
                table: "Payments",
                column: "BillId1",
                principalSchema: "billing",
                principalTable: "Bills",
                principalColumn: "Id");
        }
    }
}
