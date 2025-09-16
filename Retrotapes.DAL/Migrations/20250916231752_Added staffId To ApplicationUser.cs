using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Retrotapes.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedstaffIdToApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "AspNetUsers");
        }
    }
}
