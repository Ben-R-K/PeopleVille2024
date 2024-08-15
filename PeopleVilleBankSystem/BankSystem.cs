namespace PeopleVilleBankSystem;
using Interactions;
using WorldTimer;


public class BankSystem
{
    private string _name { get; set; }
    private List<Account> _accounts { get; set; }
    private string _guid { get; set; }

    public BankSystem(string name, TimerClass timerClass)
    {
        _name = name;
        _accounts = new List<Account>();

        _guid = timerClass.Subscribe(ApplyInterestToAllAccounts, TimerClass.SubscribtionTypes.Day);
    }

    public void AddAccount(string name)
    {
        Random random = new Random();

        double interestRate = random.NextDouble() * (0.1 - 0.01) + 0.01;

        string accountNumber = Guid.NewGuid().ToString();
        Account account = new Account(accountNumber, name, 0, interestRate);
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
       if (guid == _guid)
        {
            foreach (Account account in _accounts)
            {
                account.ApplyInterest();
            }

            Console.WriteLine("Interest applied to all accounts.");
        }
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

    public override string ToString()
    {
        return _name;
    }
}
