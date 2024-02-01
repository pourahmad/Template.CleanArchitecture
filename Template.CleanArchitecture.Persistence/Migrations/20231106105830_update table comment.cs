using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Template.CleanArchitecture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatetablecomment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublish",
                table: "Comment",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublish",
                table: "Comment");
        }
    }
}
