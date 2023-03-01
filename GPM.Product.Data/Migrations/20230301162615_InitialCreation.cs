#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GPM.Product.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TD_CUBE",
                columns: table => new
                {
                    TDCE_ID = table.Column<string>(type: "varchar(20)", nullable: false),
                    TDCE_X = table.Column<float>(type: "real", nullable: false),
                    TDCE_Y = table.Column<float>(type: "real", nullable: false),
                    TDCE_Z = table.Column<float>(type: "real", nullable: false),
                    TDCE_WIDTH = table.Column<float>(type: "real", nullable: false),
                    TDCE_HEIGHT = table.Column<float>(type: "real", nullable: false),
                    TDCE_DEPTH = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TD_CUBE", x => x.TDCE_ID);
                });

            migrationBuilder.InsertData(
                table: "TD_CUBE",
                columns: new[] { "TDCE_ID", "TDCE_DEPTH", "TDCE_HEIGHT", "TDCE_WIDTH", "TDCE_X", "TDCE_Y", "TDCE_Z" },
                values: new object[,]
                {
                    { "test1", 5f, 4f, 3f, 0f, 1f, 2f },
                    { "test2", 6f, 5f, 4f, 1f, 2f, 3f },
                    { "test3", 7f, 6f, 5f, 2f, 3f, 4f },
                    { "test4", 8f, 7f, 6f, 3f, 4f, 5f },
                    { "test5", 8f, 8f, 7f, 4f, 5f, 6f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TD_CUBE_TDCE_ID",
                table: "TD_CUBE",
                column: "TDCE_ID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TD_CUBE");
        }
    }
}
