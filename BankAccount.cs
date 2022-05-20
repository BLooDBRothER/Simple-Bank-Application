namespace BankApplication;

public class BankAccount
{
    private static int accountNumberSeed = 1234567890;
    private List<Transaction> allTransactions = new List<Transaction>();
    public string accontNumber { get; set; }
    public string name { get; set; }
    public decimal balance
    {
        get
        {
            decimal amount = 0m;
            foreach (var transaction in allTransactions)
            {
                amount += transaction.amount;
            }
            return amount;
        }
    }
    public BankAccount(string name, decimal initialBalance)
    {
        this.accontNumber = accountNumberSeed.ToString();
        accountNumberSeed++;
        this.name = name;
        MakeDeposit(initialBalance, DateTime.Now, "Initial Deposit");
    }
    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }
        var deposit = new Transaction(amount, date, note);
        allTransactions.Add(deposit);
    }
    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }
        else if (balance - amount < 0)
        {
            throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        }
        var withdrawal = new Transaction(-amount, date, note);
        allTransactions.Add(withdrawal);
    }

    public string GetAccountBalance(){
        var report = new System.Text.StringBuilder();
        decimal balance = 0;

        report.AppendLine("Date\t\tAmount\tBalance\t\tNote");

        foreach(var transaction in allTransactions){
            balance += transaction.amount;
            report.AppendLine($"{transaction.date.ToShortDateString()}\t{transaction.amount}\t{balance}\t\t{transaction.note}");
        }
        return report.ToString();
    }

    public virtual void PerfomeMonthEndTransactions() { }
}