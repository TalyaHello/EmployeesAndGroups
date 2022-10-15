using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeesAndGroups.Migrations
{
    public partial class DbAddEmployeeGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO EmployeeGroup " +
                                 "VALUES (1,1), (1,2), " +
                                        "(2,1), (3,1)," +
                                        "(4,2), (5,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM EmployeeGroup" +
                                 "WHERE ID < 7");
        }
    }
}
