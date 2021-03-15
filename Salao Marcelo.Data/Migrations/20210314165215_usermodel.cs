using Microsoft.EntityFrameworkCore.Migrations;

namespace Salao_Marcelo.Data.Migrations
{
    public partial class usermodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CashFlow_CashFlows_CashierId",
                table: "CashFlow");

            migrationBuilder.DropForeignKey(
                name: "FK_CashFlow_CashFlows_CashierId1",
                table: "CashFlow");

            migrationBuilder.DropTable(
                name: "CashFlows");

            migrationBuilder.DropIndex(
                name: "IX_CashFlow_CashierId",
                table: "CashFlow");

            migrationBuilder.DropIndex(
                name: "IX_CashFlow_CashierId1",
                table: "CashFlow");

            migrationBuilder.DropColumn(
                name: "CashierId",
                table: "CashFlow");

            migrationBuilder.DropColumn(
                name: "CashierId1",
                table: "CashFlow");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Mail = table.Column<string>(type: "varchar(100)", nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.AddColumn<int>(
                name: "CashierId",
                table: "CashFlow",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CashierId1",
                table: "CashFlow",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CashFlows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashFlows", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashFlow_CashierId",
                table: "CashFlow",
                column: "CashierId");

            migrationBuilder.CreateIndex(
                name: "IX_CashFlow_CashierId1",
                table: "CashFlow",
                column: "CashierId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CashFlow_CashFlows_CashierId",
                table: "CashFlow",
                column: "CashierId",
                principalTable: "CashFlows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CashFlow_CashFlows_CashierId1",
                table: "CashFlow",
                column: "CashierId1",
                principalTable: "CashFlows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
