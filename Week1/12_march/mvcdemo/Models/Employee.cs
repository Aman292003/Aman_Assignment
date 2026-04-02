namespace mvcdemo.Models
{
    public class Employee
    {
        public int EmployeeId { set; get; }

        public string? EmpName { set; get; }

        public int Salary { set; get; }

        public string? ImageUrl { set; get; }

        public int DeptId { set; get; }

        public Department? Department { set; get; }
    }

}
