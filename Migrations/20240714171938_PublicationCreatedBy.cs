using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Socialize.Migrations
{
    /// <inheritdoc />
    public partial class PublicationCreatedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Publication",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Publication_CreatedById",
                table: "Publication",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Publication_User_CreatedById",
                table: "Publication",
                column: "CreatedById",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publication_User_CreatedById",
                table: "Publication");

            migrationBuilder.DropIndex(
                name: "IX_Publication_CreatedById",
                table: "Publication");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Publication");
        }
    }
}
