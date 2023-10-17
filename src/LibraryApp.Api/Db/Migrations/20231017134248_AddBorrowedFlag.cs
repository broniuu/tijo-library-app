using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddBorrowedFlag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountOfBorrowedPrintCopies",
                table: "Books",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalCountOfPrintCopies",
                table: "Books",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountOfBorrowedPrintCopies",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "TotalCountOfPrintCopies",
                table: "Books");
        }
    }
}
