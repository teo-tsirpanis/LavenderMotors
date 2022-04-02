using LavenderMotors.Entities;

namespace LavenderMotors.Web.Models;

public class CustomerListViewModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public string TIN { get; set; }
    public CustomerListViewModel()
    {

    }
    public CustomerListViewModel(Customer customer)
    {
        Name = customer.Name;
        Surname = customer.Surname;
        Phone = customer.Phone;
        TIN = customer.TIN;
    }
}

public class CustomerCreateViewModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public string TIN { get; set; }
    public CustomerCreateViewModel()
    {

    }
    public CustomerCreateViewModel(Customer customer)
    {
        Name = customer.Name;
        Surname = customer.Surname;
        Phone = customer.Phone;
        TIN = customer.TIN;

    }
}

public class CustomerUpdateViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public string TIN { get; set; }
    public CustomerUpdateViewModel()
    {

    }
    public CustomerUpdateViewModel(Customer customer)
    {
        Id= customer.Id;
        Name = customer.Name;
        Surname = customer.Surname;
        Phone = customer.Phone;
        TIN = customer.TIN;

    }
}

public class CustomerFinishViewModel
{
    public Guid Id { get; set; }
    public CustomerFinishViewModel()
    {
            
    }
    public CustomerFinishViewModel(Customer customer)
    {
        Id=customer.Id;
    }
}

public class CustomerDeleteViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public string TIN { get; set; }
    public CustomerDeleteViewModel()
    {

    }
    public CustomerDeleteViewModel(Customer customer)
    {
        Id = customer.Id;
        Name = customer.Name;
        Surname = customer.Surname;
        Phone = customer.Phone;
        TIN = customer.TIN;

    }
}
