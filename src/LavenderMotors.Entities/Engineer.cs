namespace LavenderMotors.Entities;

public class Engineer : Employee
{
    private Manager? _manager;
    public bool HasManager => _manager is not null;
    public Manager Manager
    {
        get => _manager ?? throw Utilities.CreateUnboundValueAccessException();
        set => _manager = value;
    }
    public Guid ManagerId { get; set; }

    public Engineer(string name, string surname, decimal salaryPerMonth) : base(name, surname, salaryPerMonth)
    {
    }
}
