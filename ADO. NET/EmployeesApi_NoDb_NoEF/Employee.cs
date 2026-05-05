namespace EmployeesApi_NoDb_NoEF
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public double Salary { get; set; }
    }

    public static class EmployeeStore
    {
        public static List<Employee> Employees = new List<Employee>()
    {
        new Employee { Id = 1, Name = "Nandeesh", Role = "Developer", Salary = 50000 },
        new Employee { Id = 2, Name = "Rahul", Role = "Tester", Salary = 40000 }
    };
    }
}
