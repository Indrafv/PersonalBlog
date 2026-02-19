using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalBlog.Migrations
{
    /// <inheritdoc />
    public partial class admin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "IdUser", "name", "password" },
                values: new object[] { 1, "admin", "AQAAAAIAAYagAAAAEMYq1xJ2VwMtopO4udI43FAgICG1JAnZJRvSqAzgOZnVNBLpBW/z3b84PLWSzIVy7A==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "IdUser",
                keyValue: 1);
        }
    }
}
