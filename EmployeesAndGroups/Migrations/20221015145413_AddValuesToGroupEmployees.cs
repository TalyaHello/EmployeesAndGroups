using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeesAndGroups.Migrations
{
    public partial class AddValuesToGroupEmployees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Groups VALUES ('Отдел кадров'),('ЦРПО');" +
                                 "INSERT INTO Employees VALUES ('Тимофеев Г.А.', 'еtimofeev@mail.ru'), " +
                                                              "('Федоров М.М.','krasavchik@mail.ru'), " +
                                                              "('Сергеев С.С.','kras@gmail.com');" +
                                 "INSERT INTO EmployeeGroup VALUES (6,3),(7,3),(8,4)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
