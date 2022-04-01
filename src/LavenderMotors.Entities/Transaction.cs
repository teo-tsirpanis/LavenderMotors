namespace LavenderMotors.Entities;

public class Transaction
{
    private Customer? _customer;
    private Car? _car;
    private Manager? _manager;

    public Guid Id { get; }
    public DateTime Date { get; set; }
    public Customer Customer
    {
        get => _customer ?? throw Utilities.CreateUnboundValueAccessException();
        set => _customer = value;
    }
    public Car Car
    {
        get => _car ?? throw Utilities.CreateUnboundValueAccessException();
        set => _car = value;
    }
    public Manager Manager
    {
        get => _manager ?? throw Utilities.CreateUnboundValueAccessException();
        set => _manager = value;
    }
    public decimal TotalPrice { get; }

    public List<Transaction> Transactions { get; set; } = new();
}
