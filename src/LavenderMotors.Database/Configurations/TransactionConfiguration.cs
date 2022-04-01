using LavenderMotors.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LavenderMotors.Database.Configurations;

internal sealed class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("Transactions", nameof(LavenderMotors));
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        builder.Property(c => c.Date).IsRequired();
        builder.HasOne(c => c.Car).WithMany();
        builder.HasOne(c => c.Customer).WithMany();
        builder.HasOne(c => c.Manager).WithMany();
        builder.HasMany(c => c.Lines).WithOne(c => c.Transaction).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Ignore(c => c.TotalPrice);
    }
}
