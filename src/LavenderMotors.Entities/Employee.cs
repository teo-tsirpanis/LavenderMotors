namespace LavenderMotors.Entities;

public abstract class Employee
{
    public Guid Id { get; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public decimal SalaryPerMonth { get; set; }

    public Employee(string name, string surname, decimal salaryPerMonth)
    {
        Name = name;
        Surname = surname;
        SalaryPerMonth = salaryPerMonth;
    }
}
