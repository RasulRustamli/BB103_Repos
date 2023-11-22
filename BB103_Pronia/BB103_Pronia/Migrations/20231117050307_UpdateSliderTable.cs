using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BB103_Pronia.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSliderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BgImgUrl",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BgImgUrl",
                table: "Sliders");
        }
    }
}
