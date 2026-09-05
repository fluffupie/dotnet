using McbaExample.Models;
using Microsoft.EntityFrameworkCore;

namespace McbaExample.Data;

// Bonus Material: Storing data protection keys in the database using EF Core. Implement IDataProtectionKeyContext.
// NOTE: Need to add migration and update database.
//public class McbaContext : DbContext, IDataProtectionKeyContext
public class McbaContext : DbContext
{
    public McbaContext(DbContextOptions<McbaContext> options) : base(options)
    { }

    // Bonus Material: Storing data protection keys in the database using EF Core. Implement IDataProtectionKeyContext.
    //public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Login> Logins { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    // Fluent-API.
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Set check constraints (cannot be expressed with data annotations).
        builder.Entity<Login>().ToTable(b =>
        {
            b.HasCheckConstraint("CK_Login_LoginID", "len(LoginID) = 8");
            b.HasCheckConstraint("CK_Login_PasswordHash", "len(PasswordHash) = 94");
        });
        builder.Entity<Account>().ToTable(b =>
        {
            b.HasCheckConstraint(
                "CK_Account_Balance",
                $"AccountType = {(int) AccountType.Saving} and Balance >= 0 or " +
                $"AccountType = {(int) AccountType.Checking} and Balance >= -100"
            );
        });
        builder.Entity<Transaction>().ToTable(b =>
        {
            b.HasCheckConstraint("CK_Transaction_Amount", "Amount > 0");
            b.HasCheckConstraint(
                "CK_Transaction_OnlyTransferCanSetDestination",
                $"TransactionType = {(int) TransactionType.Transfer} or DestinationAccountNumber is null"
            );
            b.HasCheckConstraint(
                "CK_Transaction_CannotTransferToSelf",
                "DestinationAccountNumber is null or DestinationAccountNumber != AccountNumber"
            );
        });

        // Configure ambiguous Account.Transactions navigation property relationship.
        //builder.Entity<Transaction>().
        //    HasOne(x => x.Account).WithMany(x => x.Transactions).HasForeignKey(x => x.AccountNumber);
    }
}
