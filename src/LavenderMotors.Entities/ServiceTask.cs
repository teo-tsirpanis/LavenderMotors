namespace LavenderMotors.Entities;

public class ServiceTask
{
    // The ID will be automatically set by the database.
    public Guid Id { get; }
    public string Code { get; set; }
    public string Description { get; set; }
    public decimal Hours { get; set; }

    public ServiceTask(string code, string description, decimal hours)
    {
        Code = code;
        Description = description;
        Hours = hours;
    }
}
