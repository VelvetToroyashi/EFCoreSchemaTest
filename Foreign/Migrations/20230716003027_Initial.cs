using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ClassLibrary1.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "foreign");

            migrationBuilder.CreateTable(
                name: "CoreEntity",
                schema: "foreign",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoreEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ForeignEntities",
                schema: "foreign",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Thing = table.Column<string>(type: "text", nullable: false),
                    CoreEntityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForeignEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForeignEntities_CoreEntity_CoreEntityId",
                        column: x => x.CoreEntityId,
                        principalSchema: "foreign",
                        principalTable: "CoreEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForeignEntities_CoreEntityId",
                schema: "foreign",
                table: "ForeignEntities",
                column: "CoreEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForeignEntities",
                schema: "foreign");

            migrationBuilder.DropTable(
                name: "CoreEntity",
                schema: "foreign");
        }
    }
}
