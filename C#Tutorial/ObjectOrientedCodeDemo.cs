using System;

public class Account
{
    public Account(string bsb, string accountNumber, decimal balance, Person accountHolder)
    {
        if (string.IsNullOrWhiteSpace(bsb))
            throw new ArgumentException("BSB is required.", nameof(bsb));

        if (string.IsNullOrWhiteSpace(accountNumber))
            throw new ArgumentException("Account number is required.", nameof(accountNumber));

        if (balance < 0)
            throw new ArgumentOutOfRangeException(nameof(balance), "Balance cannot be negative.");

        AccountHolder = accountHolder ?? throw new ArgumentNullException(nameof(accountHolder));

        Bsb = bsb;
        AccountNumber = accountNumber;
        Balance = balance;
    }

    public string Bsb { get; }
    public string AccountNumber { get; }
    public decimal Balance { get; private set; } // Balance has a private setter, so only the Account class can change it
    public Person AccountHolder { get; }

    public bool Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal amount must be positive.");

        if (amount > Balance)
            return false;

        Balance -= amount;
        return true;
    }
}

public class Person
{
    public Person(string firstName, string lastName, DateTime dateOfBirth)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("First name is required.", nameof(firstName));

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Last name is required.", nameof(lastName));

        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
    }

    public string FirstName { get; }
    public string LastName { get; }
    public DateTime DateOfBirth { get; }

    public string FullName => $"{FirstName} {LastName}";
}

public static class ObjectOrientedCodeDemo
{
    public static void Run()
    {
        var person = new Person("Bob", "Smith", new DateTime(1990, 6, 20));
        var account = new Account("062-620", "12341234", 500.00m, person);

        PrintBankDetails(account);

        TryWithdraw(account, 250.00m);
        TryWithdraw(account, 750.00m);
        PrintBankDetails(account);

        TryWithdraw(account, 750.00m);
        PrintBankDetails(account);
    }

    private static void TryWithdraw(Account account, decimal amount)
    {
        if (account.Withdraw(amount))
        {
            Console.WriteLine($"Successfully withdrew {amount:C}.");
        }
        else
        {
            Console.WriteLine($"Withdrawal of {amount:C} failed due to insufficient funds.");
        }
    }

    private static void PrintBankDetails(Account account)
    {
        Console.WriteLine("Bank Details");
        Console.WriteLine($"BSB           : {account.Bsb}");
        Console.WriteLine($"Account Number: {account.AccountNumber}");
        Console.WriteLine($"Balance       : {account.Balance:C}");
        Console.WriteLine($"Account Owner : {account.AccountHolder.FullName}");
        Console.WriteLine();
    }
}
