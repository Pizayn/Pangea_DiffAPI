using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diff.Infastructure.Migrations
{
    public partial class code : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Differences",
                newName: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Differences",
                newName: "Id");
        }
    }
}
