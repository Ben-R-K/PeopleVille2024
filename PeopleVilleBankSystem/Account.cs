namespace PeopleVilleBankSystem;

public class Account
{
    private string _accountNumber { get; set; }
    private string _accountHolder { get; set; }
    private double _balance { get; set; }

    public Account(string accountNumber, string accountHolder, double balance)
    {
        _accountNumber = accountNumber;
        _accountHolder = accountHolder;
        _balance = balance;
    }

    public void Deposit(double amount)
    {
        _balance += amount;
    }

    public void Withdraw(double amount)
    {
        _balance -= amount;
    }

    public double GetBalance()
    {
        return _balance;
    }

    public string GetAccountHolder()
    {
        return _accountHolder;
    }

    public string GetAccountNumber()
    {
        return _accountNumber;
    }

    public void Transfer(Account destinationAccount, double amount)
    {
        Withdraw(amount);
        destinationAccount.Deposit(amount);
    }
}