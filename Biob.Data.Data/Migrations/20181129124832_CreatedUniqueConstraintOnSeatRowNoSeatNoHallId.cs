using Microsoft.EntityFrameworkCore.Migrations;

namespace Biob.Data.Data.Migrations
{
    public partial class CreatedUniqueConstraintOnSeatRowNoSeatNoHallId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Seats_RowNo_SeatNo_HallId",
                table: "Seats",
                columns: new[] { "RowNo", "SeatNo", "HallId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Seats_RowNo_SeatNo_HallId",
                table: "Seats");
        }
    }
}
