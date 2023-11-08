using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.DAL.Migrations
{
    /// <inheritdoc />
    public partial class update2productclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(38,17)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5c4644d-4e15-43be-9ca3-47bc29689f33", "AQAAAAIAAYagAAAAEJ20VGqJnYxrkWyCpwACiBZ2vqAmwKX2C8zbHLBzd4F+wRx/a0rjIrd9UuuAt3myww==", "deb61e40-2928-4e01-9be3-829784f83e62" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,17)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "759625f3-bd58-4d55-8e43-fd2640c4a90d", "AQAAAAIAAYagAAAAEFtRNpOvYB2OzU5qiu+gLRJIDEum0Se/mAK0wK5vZNltF4H7tQDCyIijaCvwIl3MpQ==", "601566f2-cde5-402e-ab1e-30313d8425a0" });
        }
    }
}
