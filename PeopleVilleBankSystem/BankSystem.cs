using WorldTimer;
namespace PeopleVilleBankSystem;

public class BankSystem
{
    private List<Account> _accounts { get; set; }
    private string _applyInterestGUID { get; set; }
    private string _printAllAccountsGUID { get; set; }

    public BankSystem(TimerClass timerClass)
    {
        _accounts = new List<Account>();

        _applyInterestGUID = timerClass.Subscribe(ApplyInterestToAllAccounts, TimerClass.SubscribtionTypes.Day);
        _printAllAccountsGUID = timerClass.Subscribe(PrintAllAccounts, TimerClass.SubscribtionTypes.Hour);
    }

    public void AddAccount(string name)
    {
        Random random = new Random();

        double interestRate = random.NextDouble() * (0.1 - 0.01) + 0.01;

        string accountNumber = Guid.NewGuid().ToString();

        int balance = random.Next(0, 10000);

        Console.WriteLine($"Account: {name} created with balance {balance}");

        Account account = new Account(accountNumber, name, balance, interestRate);
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

    private void ApplyInterestToAllAccounts(int hours, int minutes, int seconds, string guid)
    {
        if (guid == _applyInterestGUID)
        {
            foreach (Account account in _accounts)
            {
                account.ApplyInterest();
            }

            Console.WriteLine("Interest applied to all accounts.");
        }
    }

    public void PrintAllAccounts(int hours, int minutes, int seconds, string guid)
    {
        if (guid == _printAllAccountsGUID && hours % 4 == 0)
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
}
