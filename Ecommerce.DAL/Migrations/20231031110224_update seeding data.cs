using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateseedingdata : Migration
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
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f84f7bee-f2c8-4a42-a004-690e8058148a", false, "AQAAAAIAAYagAAAAEEn8PpPpSN9jo31LolhtyiESczBESvTbGqeI/cm+VBtsYaLRWs3DxJoFmPW9XwiYxA==", "5ecba8fa-fa65-4d60-9245-7fe10a89e79e" });
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
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8755b4a6-652b-4a88-8e03-d0c828b72520", true, "AQAAAAIAAYagAAAAEBIlOWlk6Hz1EYmdIHDaZflwuIGq3G2yGJlO7I1Vd+UiabKM3Y56qCniZOTmPvVECw==", "6c7ca72e-041b-49b8-835f-ebfbbfb8791f" });
        }
    }
}
