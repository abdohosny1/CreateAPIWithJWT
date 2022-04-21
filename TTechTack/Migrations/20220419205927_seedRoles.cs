using Microsoft.EntityFrameworkCore.Migrations;
using TTechTack.Data.Static;

#nullable disable

namespace TTechTack.Migrations
{
    public partial class seedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "AspNetRoles",
               columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
               values: new object[] { Guid.NewGuid().ToString(), UserRoles.User, UserRoles.User.ToUpper(), Guid.NewGuid().ToString() }
           );

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), UserRoles.Admin, UserRoles.Admin.ToUpper(), Guid.NewGuid().ToString() }
            );
            migrationBuilder.InsertData(
              table: "AspNetRoles",
              columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
              values: new object[] { Guid.NewGuid().ToString(), UserRoles.Manager, UserRoles.Manager.ToUpper(), Guid.NewGuid().ToString() }
          );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [AspNetRoles]");

        }
    }
}
