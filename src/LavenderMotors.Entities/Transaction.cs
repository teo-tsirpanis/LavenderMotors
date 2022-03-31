namespace LavenderMotors.Entities;

public class Transaction
{
    public Guid Id { get; }
    public DateTime Date { get; }
    public Customer Customer { get; }
    public Car Car { get; }
    public Manager Manager { get; }
    public decimal TotalPrice { get; }

    public List<Transaction> Transactions { get; } = new();

    public Transaction(DateTime date, Customer customer, Car car, Manager manager)
    {
        Date = date;
        Customer = customer;
        Car = car;
        Manager = manager;
    }
}
