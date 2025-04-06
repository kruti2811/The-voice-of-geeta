using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_voice_of_geeta.Migrations
{
    /// <inheritdoc />
    public partial class AddShlokasTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shlokas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdhyayNumber = table.Column<int>(type: "int", nullable: false),
                    ShlokaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shlokas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shlokas");
        }
    }
}
