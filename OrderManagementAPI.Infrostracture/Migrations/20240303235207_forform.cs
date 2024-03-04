using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManagementAPI.Infrostracture.Migrations
{
    /// <inheritdoc />
    public partial class forform : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "path",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "path",
                table: "Users");
        }
    }
}
