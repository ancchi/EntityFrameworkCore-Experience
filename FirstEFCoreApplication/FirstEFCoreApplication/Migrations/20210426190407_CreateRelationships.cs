using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstEFCoreApplication.Migrations
{
    public partial class CreateRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResidentId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ResidentCareTaker",
                columns: table => new
                {
                    CareTakerId = table.Column<int>(type: "int", nullable: false),
                    ResidentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentCareTaker", x => new { x.CareTakerId, x.ResidentId });
                    table.ForeignKey(
                        name: "FK_ResidentCareTaker_CareTakers_CareTakerId",
                        column: x => x.CareTakerId,
                        principalTable: "CareTakers",
                        principalColumn: "CareTakerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentCareTaker_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "ResidentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_ResidentId",
                table: "Rooms",
                column: "ResidentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResidentCareTaker_ResidentId",
                table: "ResidentCareTaker",
                column: "ResidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Residents_ResidentId",
                table: "Rooms",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "ResidentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Residents_ResidentId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "ResidentCareTaker");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_ResidentId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ResidentId",
                table: "Rooms");
        }
    }
}
