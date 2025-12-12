using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace technova_ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class addinguser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "hased_password",
                table: "User",
                newName: "hashed_password");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "hashed_password",
                table: "User",
                newName: "hased_password");
        }
    }
}
