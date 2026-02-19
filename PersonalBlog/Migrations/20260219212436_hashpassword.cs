using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalBlog.Migrations
{
    /// <inheritdoc />
    public partial class hashpassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "IdUser",
                keyValue: 1,
                column: "password",
                value: "AQAAAAEAACcQAAAAEBD1bWCP9WNPPBK/VD8R4FBe/TlNQZ2PDH/SvlCR/R8vVhaR1JCHZSDgr5hPSlP8wA==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "IdUser",
                keyValue: 1,
                column: "password",
                value: "AQAAAAIAAYagAAAAEMYq1xJ2VwMtopO4udI43FAgICG1JAnZJRvSqAzgOZnVNBLpBW/z3b84PLWSzIVy7A==");
        }
    }
}
