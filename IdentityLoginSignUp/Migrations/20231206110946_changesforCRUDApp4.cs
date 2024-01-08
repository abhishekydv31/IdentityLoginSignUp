using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityLoginSignUp.Migrations
{
    /// <inheritdoc />
    public partial class changesforCRUDApp4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "MobileNo",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Student",
                newName: "Student Name");

            migrationBuilder.AlterColumn<string>(
                name: "Student Name",
                table: "Student",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MotherName",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "MotherName",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "Student Name",
                table: "Student",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MobileNo",
                table: "Student",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }
    }
}
