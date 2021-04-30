using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstEFCoreApplication.Migrations
{
    public partial class UpdateOneToManyForVisitorsResident : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_Residents_ResidentId",
                table: "Visitors");

            migrationBuilder.AlterColumn<int>(
                name: "ResidentId",
                table: "Visitors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_Residents_ResidentId",
                table: "Visitors",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "ResidentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_Residents_ResidentId",
                table: "Visitors");

            migrationBuilder.AlterColumn<int>(
                name: "ResidentId",
                table: "Visitors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_Residents_ResidentId",
                table: "Visitors",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "ResidentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
