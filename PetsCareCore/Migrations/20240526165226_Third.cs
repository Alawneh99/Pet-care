using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetsCareCore.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Clinics",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_UserID",
                table: "Clinics",
                column: "UserID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_Users_UserID",
                table: "Clinics",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_Users_UserID",
                table: "Clinics");

            migrationBuilder.DropIndex(
                name: "IX_Clinics_UserID",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Clinics");
        }
    }
}
