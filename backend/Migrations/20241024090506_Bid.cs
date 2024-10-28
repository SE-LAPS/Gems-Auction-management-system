using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class Bid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36299744-a277-4505-a752-154941075781");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3931d03-0326-4ca7-8f6d-2d3ddcd78fb1");

            migrationBuilder.AddColumn<bool>(
                name: "IsPaymentCaptured",
                table: "Bid",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8d69a86b-1c23-41e0-8427-92afd10365df", null, "User", "USER" },
                    { "92b5e488-3a33-404c-86b2-369b863a1675", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d69a86b-1c23-41e0-8427-92afd10365df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92b5e488-3a33-404c-86b2-369b863a1675");

            migrationBuilder.DropColumn(
                name: "IsPaymentCaptured",
                table: "Bid");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "36299744-a277-4505-a752-154941075781", null, "User", "USER" },
                    { "b3931d03-0326-4ca7-8f6d-2d3ddcd78fb1", null, "Admin", "ADMIN" }
                });
        }
    }
}
