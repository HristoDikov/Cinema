namespace Cinema.Infrastructure.Persistance.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class Addavailableseatsinprojection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvailableSeats",
                table: "Projections",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableSeats",
                table: "Projections");
        }
    }
}
