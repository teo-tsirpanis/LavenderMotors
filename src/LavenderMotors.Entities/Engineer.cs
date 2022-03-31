namespace LavenderMotors.Entities;

public class Engineer : Employee
{
    public Manager Manager { get; set; }

    public Engineer(string name, string surname, decimal salaryPerMonth, Manager manager) : base(name, surname, salaryPerMonth)
    {
        Manager = manager;
    }
}
