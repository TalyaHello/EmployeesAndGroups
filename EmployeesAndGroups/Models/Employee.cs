namespace EmployeesAndGroups.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<Group> Groups { get; set; }
    }
}
