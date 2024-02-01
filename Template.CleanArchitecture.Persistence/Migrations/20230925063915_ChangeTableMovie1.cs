using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Template.CleanArchitecture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTableMovie1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Movie",
                newName: "IsDisable");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDisable",
                table: "Movie",
                newName: "IsDeleted");
        }
    }
}
