using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreApp.Migrations
{
    public partial class SeedDataIdentityUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ae755206-177c-4f9b-8638-2c22cc8b9aa0", "AQAAAAEAACcQAAAAEH9GLzMw7SRfaGYmgwmOaCw/LSGJa3fPX3oc6cVYCQnCLXSUuDcaPJEUzOKFrAXAuw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "638e5169-0e4a-4e8e-8421-4cf55cdc3d42");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user",
                column: "ConcurrencyStamp",
                value: "dc434dc9-8a04-4459-8929-26b4b37b2afc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin_user",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "39e08f0d-37d2-43f3-a301-a8e77adcbfd5", "AQAAAAEAACcQAAAAEAW8OKGcXK1626NkNB9SSHibNEKNOxD2Vjn8LdePQDLuYBG2yezvpZ1T1jp6Pe5EmA==" });
        }
    }
}
