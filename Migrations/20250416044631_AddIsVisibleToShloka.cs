using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_voice_of_geeta.Migrations
{
    /// <inheritdoc />
    public partial class AddIsVisibleToShloka : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShlokaDescription",
                table: "Shlokas",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsVisible",
                table: "Shlokas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVisible",
                table: "Shlokas");

            migrationBuilder.AlterColumn<string>(
                name: "ShlokaDescription",
                table: "Shlokas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);
        }
    }
}
