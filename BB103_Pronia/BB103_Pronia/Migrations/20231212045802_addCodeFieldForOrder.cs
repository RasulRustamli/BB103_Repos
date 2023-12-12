using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BB103_Pronia.Migrations
{
    /// <inheritdoc />
    public partial class addCodeFieldForOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Orders");
        }
    }
}
