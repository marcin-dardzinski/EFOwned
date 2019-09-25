using Microsoft.EntityFrameworkCore.Migrations;

namespace EFOwned.Migrations
{
    public partial class Recreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Child_Parents_ParentId",
                table: "Child");

            migrationBuilder.AddForeignKey(
                name: "FK_Child_Parents_ParentId",
                table: "Child",
                column: "ParentId",
                principalTable: "Parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Child_Parents_ParentId",
                table: "Child");

            migrationBuilder.AddForeignKey(
                name: "FK_Child_Parents_ParentId",
                table: "Child",
                column: "ParentId",
                principalTable: "Parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
