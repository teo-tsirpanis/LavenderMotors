using LavenderMotors.Entities;

namespace LavenderMotors.Web.Models;

public class TransactionSummaryViewModel
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; }
    public Guid CarId { get; set; }
    public string CarRegistrationNumber { get; set; }
    public Guid ManagerId { get; set; }
    public string ManagerName { get; set; }
    public int LineCount { get; set; }
    public decimal TotalPrice { get; set; }

    public TransactionSummaryViewModel(Transaction transaction)
    {
        Id = transaction.Id;
        Date = transaction.Date;
        CustomerId = transaction.CustomerId;
        CustomerName = transaction.Customer.Name;
        CarId = transaction.CarId;
        CarRegistrationNumber = transaction.Car.CarRegistrationNumber;
        ManagerId = transaction.ManagerId;
        ManagerName = transaction.Manager.Name;
        LineCount = transaction.Lines.Count;
        TotalPrice = transaction.TotalPrice;
    }
}

public class TransactionCreateViewModel
{
    public DateTime Date { get; set; }
    public Guid CustomerId { get; set; }
    public Guid CarId { get; set; }
    public Guid ManagerId { get; set; }
}

public class TransactionEditViewModel
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public Guid CustomerId { get; set; }
    public Guid CarId { get; set; }
    public Guid ManagerId { get; set; }

    public TransactionEditViewModel() { }

    public TransactionEditViewModel(Transaction transaction)
    {
        Id = transaction.Id;
        Date = transaction.Date;
        CustomerId = transaction.CustomerId;
        CarId = transaction.CarId;
        ManagerId = transaction.ManagerId;
    }
}
