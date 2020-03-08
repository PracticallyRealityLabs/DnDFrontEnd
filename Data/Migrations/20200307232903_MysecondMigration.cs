using Microsoft.EntityFrameworkCore.Migrations;

namespace DnDFrontEnd.Data.Migrations
{
    public partial class MysecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CampaignName",
                table: "Campaign",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CampaignName",
                table: "Campaign");
        }
    }
}
