using Microsoft.EntityFrameworkCore.Migrations;

namespace JolumaPOS_v._2._0.Data.Migrations
{
    public partial class AgregadoForgotPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ForgotPassword",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForgotPassword",
                table: "AspNetUsers");
        }
    }
}
