using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExchangeBook.Migrations
{
    /// <inheritdoc />
    public partial class Notifications_edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Notifications_InterestedId",
                table: "Notifications",
                column: "InterestedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_USERS_InterestedId",
                table: "Notifications",
                column: "InterestedId",
                principalTable: "USERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_USERS_InterestedId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_InterestedId",
                table: "Notifications");
        }
    }
}
