using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApartmentId",
                table: "ExpenseTypes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseTypes_ApartmentId",
                table: "ExpenseTypes",
                column: "ApartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseTypes_Apartments_ApartmentId",
                table: "ExpenseTypes",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseTypes_Apartments_ApartmentId",
                table: "ExpenseTypes");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseTypes_ApartmentId",
                table: "ExpenseTypes");

            migrationBuilder.DropColumn(
                name: "ApartmentId",
                table: "ExpenseTypes");
        }
    }
}
