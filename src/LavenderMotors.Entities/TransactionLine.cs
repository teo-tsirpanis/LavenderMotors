namespace LavenderMotors.Entities;

public class TransactionLine
{
    public Guid Id { get; }
    public Transaction Transaction { get; }
    public ServiceTask ServiceTask { get; }
    public Engineer Engineer { get; }
    public decimal Hours { get; }
    public decimal PricePerHour { get; }
    public decimal Price { get; }

    public TransactionLine(Transaction transaction, ServiceTask serviceTask, Engineer engineer, uint hours, decimal pricePerHour)
    {
        Transaction = transaction;
        ServiceTask = serviceTask;
        Engineer = engineer;
        Hours = hours;
        PricePerHour = pricePerHour;
    }
}
