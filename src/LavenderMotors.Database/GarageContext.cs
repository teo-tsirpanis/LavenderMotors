using LavenderMotors.Database.Configurations;
using LavenderMotors.Entities;
using Microsoft.EntityFrameworkCore;

namespace LavenderMotors.Database;

public class GarageContext : DbContext
{
    private readonly string _connectionString;

    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Car> Cars { get; set; } = null!;
    public DbSet<ServiceTask> ServiceTasks { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Engineer> Engineers { get; set; } = null!;
    public DbSet<Manager> Managers { get; set; } = null!;
    public DbSet<Transaction> Transactions { get; set; } = null!;

    public GarageContext()
    {
        _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Database=LavenderMotors;";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CarConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new ServiceTaskConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new EngineerConfiguration());
        modelBuilder.ApplyConfiguration(new ManagerConfiguration());
        modelBuilder.ApplyConfiguration(new TransactionConfiguration());
        modelBuilder.ApplyConfiguration(new TransactionLineConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
