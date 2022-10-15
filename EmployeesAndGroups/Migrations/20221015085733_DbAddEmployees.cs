using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeesAndGroups.Migrations
{
    public partial class DbAddEmployees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Employees " +
                                 "VALUES ('Дмитриева Н.Д.', 'akva888@mail.ru'), " +
                                        "('Борисова А.А.', 'leksa123@mail.ru'), " +
                                        "('Иванов И.И.', 'ivanovII111@mail.ru')," +
                                        "('Андреев А.А.', 'andreevAA@mail.ru')," +
                                        "('Павлов В.М.','pavlovVM@mail.ru')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Employees" +
                                 "WHERE FullName='Дмитриева Н.Д.'" +
                                    "OR FullName='Борисова А.А'" +
                                    "OR FullName='Иванов И.И.'" +
                                    "OR FullName='Андреев А.А.'" +
                                    "OR FullName='Павлов В.М.");
        }
    }
}
