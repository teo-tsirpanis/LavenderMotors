namespace LavenderMotors.Entities;

public class Customer
{
    // The ID will be automatically set by the database.
    public Guid Id { get; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    /// <summary>
    /// Tax Identification Number
    /// </summary>
    /// <remarks>
    /// In Greece it is known as "ΑΦΜ".
    /// </remarks>
    public string TIN { get; set; }
    
    public Customer(string name, string surname, string phone, string tin)
    {
        Name = name;
        Surname = surname;
        Phone = phone;
        TIN = tin;
    }
}
