using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeesAndGroups.Migrations
{
    public partial class DbAddValuesToGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Groups VALUES ('Администраторы'), ('Руководство')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Groups WHERE Name = 'Администраторы' or Name = 'Руководство'");
        }
    }
}
