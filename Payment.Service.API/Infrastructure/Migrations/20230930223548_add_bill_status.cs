using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plooto.Assessment.Payment.API.Infrastructure.Migrations
{
    public partial class add_bill_status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "billing",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<int>(
                name: "Method",
                schema: "billing",
                table: "Payments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<int>(
                name: "Identifier",
                schema: "billing",
                table: "Payments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1)
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DebitDate",
                schema: "billing",
                table: "Payments",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset")
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedOn",
                schema: "billing",
                table: "Payments",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 9, 30, 22, 35, 48, 187, DateTimeKind.Unspecified).AddTicks(7255), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 9, 30, 20, 9, 38, 683, DateTimeKind.Unspecified).AddTicks(5316), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<Guid>(
                name: "BillId",
                schema: "billing",
                table: "Payments",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("Relational:ColumnOrder", 6);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                schema: "billing",
                table: "Payments",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedOn",
                schema: "billing",
                table: "Bills",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 9, 30, 22, 35, 48, 190, DateTimeKind.Unspecified).AddTicks(3569), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 9, 30, 20, 9, 38, 687, DateTimeKind.Unspecified).AddTicks(4819), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "_billStatusId",
                schema: "billing",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BillStatus",
                schema: "billing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bills__billStatusId",
                schema: "billing",
                table: "Bills",
                column: "_billStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_BillStatus__billStatusId",
                schema: "billing",
                table: "Bills",
                column: "_billStatusId",
                principalSchema: "billing",
                principalTable: "BillStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_BillStatus__billStatusId",
                schema: "billing",
                table: "Bills");

            migrationBuilder.DropTable(
                name: "BillStatus",
                schema: "billing");

            migrationBuilder.DropIndex(
                name: "IX_Bills__billStatusId",
                schema: "billing",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "_billStatusId",
                schema: "billing",
                table: "Bills");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "billing",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<int>(
                name: "Method",
                schema: "billing",
                table: "Payments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<int>(
                name: "Identifier",
                schema: "billing",
                table: "Payments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("Relational:ColumnOrder", 1)
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DebitDate",
                schema: "billing",
                table: "Payments",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset")
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedOn",
                schema: "billing",
                table: "Payments",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 9, 30, 20, 9, 38, 683, DateTimeKind.Unspecified).AddTicks(5316), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 9, 30, 22, 35, 48, 187, DateTimeKind.Unspecified).AddTicks(7255), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<Guid>(
                name: "BillId",
                schema: "billing",
                table: "Payments",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .OldAnnotation("Relational:ColumnOrder", 6);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                schema: "billing",
                table: "Payments",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedOn",
                schema: "billing",
                table: "Bills",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 9, 30, 20, 9, 38, 687, DateTimeKind.Unspecified).AddTicks(4819), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 9, 30, 22, 35, 48, 190, DateTimeKind.Unspecified).AddTicks(3569), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
