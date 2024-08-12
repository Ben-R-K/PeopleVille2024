namespace PeopleVilleBankSystem;

public class BankSystem
{
    private List<Account> _accounts { get; set; }

    public BankSystem()
    {
        _accounts = new List<Account>();
    }

    public void AddAccount(string name)
    {
        string accountNumber = Guid.NewGuid().ToString();
        Account account = new Account(accountNumber, name, 0);
        _accounts.Add(account);
    }

    public void RemoveAccount(string accountNumber)
    {
        Account account = GetAccount(accountNumber);
        _accounts.Remove(account);
    }

    public Account GetAccount(string accountNumber)
    {
        return _accounts.FirstOrDefault(a => a.GetAccountNumber() == accountNumber) ?? throw new Exception("Account not found");
    }

    public void Transfer(string sourceAccountNumber, string destinationAccountNumber, double amount)
    {
        Account sourceAccount = GetAccount(sourceAccountNumber);
        Account destinationAccount = GetAccount(destinationAccountNumber);

        sourceAccount.Transfer(destinationAccount, amount);
    }

    public double GetBalance(string accountNumber)
    {
        return GetAccount(accountNumber).GetBalance();
    }

    public string GetAccountHolder(string accountNumber)
    {
        return GetAccount(accountNumber).GetAccountHolder();
    }

    public void Deposit(string accountNumber, double amount)
    {
        GetAccount(accountNumber).Deposit(amount);
    }

    public void Withdraw(string accountNumber, double amount)
    {
        GetAccount(accountNumber).Withdraw(amount);
    }

    public void PrintAllAccounts()
    {
        foreach (Account account in _accounts)
        {
            Console.WriteLine($"Account Number: {account.GetAccountNumber()}");
            Console.WriteLine($"Account Holder: {account.GetAccountHolder()}");
            Console.WriteLine($"Balance: {account.GetBalance()}");
            Console.WriteLine();
        }
    }
}
