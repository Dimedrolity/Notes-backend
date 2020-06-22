using Microsoft.EntityFrameworkCore.Migrations;

namespace Notes.DAL.Migrations
{
    public partial class AddNotNullConstraintToTitlePropertyOfNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Notes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Notes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
