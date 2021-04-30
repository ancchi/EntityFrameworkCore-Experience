using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstEFCoreApplication.Migrations
{
    public partial class AddResidentCareTakerToContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResidentCareTaker_CareTakers_CareTakerId",
                table: "ResidentCareTaker");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentCareTaker_Residents_ResidentId",
                table: "ResidentCareTaker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResidentCareTaker",
                table: "ResidentCareTaker");

            migrationBuilder.RenameTable(
                name: "ResidentCareTaker",
                newName: "ResidentCareTakers");

            migrationBuilder.RenameIndex(
                name: "IX_ResidentCareTaker_ResidentId",
                table: "ResidentCareTakers",
                newName: "IX_ResidentCareTakers_ResidentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResidentCareTakers",
                table: "ResidentCareTakers",
                columns: new[] { "CareTakerId", "ResidentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentCareTakers_CareTakers_CareTakerId",
                table: "ResidentCareTakers",
                column: "CareTakerId",
                principalTable: "CareTakers",
                principalColumn: "CareTakerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentCareTakers_Residents_ResidentId",
                table: "ResidentCareTakers",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "ResidentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResidentCareTakers_CareTakers_CareTakerId",
                table: "ResidentCareTakers");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentCareTakers_Residents_ResidentId",
                table: "ResidentCareTakers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResidentCareTakers",
                table: "ResidentCareTakers");

            migrationBuilder.RenameTable(
                name: "ResidentCareTakers",
                newName: "ResidentCareTaker");

            migrationBuilder.RenameIndex(
                name: "IX_ResidentCareTakers_ResidentId",
                table: "ResidentCareTaker",
                newName: "IX_ResidentCareTaker_ResidentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResidentCareTaker",
                table: "ResidentCareTaker",
                columns: new[] { "CareTakerId", "ResidentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentCareTaker_CareTakers_CareTakerId",
                table: "ResidentCareTaker",
                column: "CareTakerId",
                principalTable: "CareTakers",
                principalColumn: "CareTakerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentCareTaker_Residents_ResidentId",
                table: "ResidentCareTaker",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "ResidentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
