using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class UpdateMasterConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detail_Master_MasterId",
                table: "Detail");

            migrationBuilder.AlterColumn<long>(
                name: "MasterId",
                table: "Detail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Common_MasterId",
                table: "Common",
                column: "MasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Common_Master_MasterId",
                table: "Common",
                column: "MasterId",
                principalTable: "Master",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Detail_Master_MasterId",
                table: "Detail",
                column: "MasterId",
                principalTable: "Master",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Common_Master_MasterId",
                table: "Common");

            migrationBuilder.DropForeignKey(
                name: "FK_Detail_Master_MasterId",
                table: "Detail");

            migrationBuilder.DropIndex(
                name: "IX_Common_MasterId",
                table: "Common");

            migrationBuilder.AlterColumn<long>(
                name: "MasterId",
                table: "Detail",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Detail_Master_MasterId",
                table: "Detail",
                column: "MasterId",
                principalTable: "Master",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
