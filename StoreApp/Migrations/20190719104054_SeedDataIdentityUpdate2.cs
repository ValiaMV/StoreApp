using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreApp.Migrations
{
    public partial class SeedDataIdentityUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "6987786f-2890-416a-98d0-b91cabbf8c1b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user",
                column: "ConcurrencyStamp",
                value: "07bcc844-ad6a-4042-8213-3a9191d4986e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin_user",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa7a2f71-0c78-4278-8964-8fbe8f6776a1", "AQAAAAEAACcQAAAAEL82bpjGsvYkuwuEV3OzI4HxHU86uoQkgZmDgYvuXZER/FclCIkIv0rrCE5ncldXHQ==", "27a57520-be6a-4ac7-9a1b-3d38b0b7f876" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "2868dacc-254f-4177-b2bf-3d0d9ad36a08");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user",
                column: "ConcurrencyStamp",
                value: "4a81bd7a-21cb-4552-b179-eaa36502647c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin_user",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae755206-177c-4f9b-8638-2c22cc8b9aa0", "AQAAAAEAACcQAAAAEH9GLzMw7SRfaGYmgwmOaCw/LSGJa3fPX3oc6cVYCQnCLXSUuDcaPJEUzOKFrAXAuw==", null });
        }
    }
}
