using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetsCareCore.Migrations
{
    /// <inheritdoc />
    public partial class eleventh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_UserRoleID",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "UserRoleID",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_UserRoleID",
                table: "Users",
                column: "UserRoleID",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_UserRoleID",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "UserRoleID",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_UserRoleID",
                table: "Users",
                column: "UserRoleID",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
