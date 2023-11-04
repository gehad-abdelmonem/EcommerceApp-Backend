using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateseedingdata2 : Migration
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
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de5f1512-9fce-4df5-a503-00ea41c22c5f", "GEHADABDELMONAM@GMAIL.COM", "AQAAAAIAAYagAAAAEPkDzabKS6iajL56FDgu0yZbw3dk31UrTdRGUOn2leCYQS/ORkdAKBUB681f4URHig==", "fcd45740-eaa2-4b0a-abfe-96b646e53df3" });
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
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f84f7bee-f2c8-4a42-a004-690e8058148a", null, "AQAAAAIAAYagAAAAEEn8PpPpSN9jo31LolhtyiESczBESvTbGqeI/cm+VBtsYaLRWs3DxJoFmPW9XwiYxA==", "5ecba8fa-fa65-4d60-9245-7fe10a89e79e" });
        }
    }
}
