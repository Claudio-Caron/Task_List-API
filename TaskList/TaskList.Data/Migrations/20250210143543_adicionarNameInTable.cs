using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskList.Data.Migrations
{
    /// <inheritdoc />
    public partial class adicionarNameInTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TaskList",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "TaskList");
        }
    }
}
