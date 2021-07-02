namespace Cinema.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class Addconnectionsbetweenprojectionandticket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectionId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ProjectionId",
                table: "Tickets",
                column: "ProjectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Projections_ProjectionId",
                table: "Tickets",
                column: "ProjectionId",
                principalTable: "Projections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Projections_ProjectionId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ProjectionId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ProjectionId",
                table: "Tickets");
        }
    }
}
