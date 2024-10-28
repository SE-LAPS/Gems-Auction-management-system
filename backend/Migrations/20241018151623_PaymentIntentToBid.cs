using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class PaymentIntentToBid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0b3a635-0edf-4b17-a407-8b7f273fcd7b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d812fd89-3828-4c59-8c30-119da6635af5");

            migrationBuilder.AddColumn<string>(
                name: "PaymentIntentId",
                table: "Bid",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "36299744-a277-4505-a752-154941075781", null, "User", "USER" },
                    { "b3931d03-0326-4ca7-8f6d-2d3ddcd78fb1", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36299744-a277-4505-a752-154941075781");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3931d03-0326-4ca7-8f6d-2d3ddcd78fb1");

            migrationBuilder.DropColumn(
                name: "PaymentIntentId",
                table: "Bid");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c0b3a635-0edf-4b17-a407-8b7f273fcd7b", null, "Admin", "ADMIN" },
                    { "d812fd89-3828-4c59-8c30-119da6635af5", null, "User", "USER" }
                });
        }
    }
}
