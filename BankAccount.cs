namespace BankApplication;

public class BankAccount
{
    private readonly decimal _minimumBalance;
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
    public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) { }
    public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
    {
        this.accontNumber = accountNumberSeed.ToString();
        accountNumberSeed++;
        this.name = name;
        _minimumBalance = minimumBalance;
        if(initialBalance > 0){
            MakeDeposit(initialBalance, DateTime.Now, "Initial Deposit");
        }
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
        if(balance - amount < _minimumBalance){
            throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        }
        Transaction? overDraftTransaction = CheckWithdrawalLimit(balance - amount < 0);
        
        var withdrawal = new Transaction(-amount, date, note);
        allTransactions.Add(withdrawal);

        if(overDraftTransaction != null){
            allTransactions.Add(overDraftTransaction);
        }
    }

    protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn){
        if(isOverdrawn){
            throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        }
        else{
            return default;
        }
    }

    public string GetAccountStatement(){
        var report = new System.Text.StringBuilder();
        decimal balance = 0;

        report.AppendLine("Date\t\tAmount\tBalance\t\tNote");

        foreach(var transaction in allTransactions){
            balance += transaction.amount;
            report.AppendLine($"{transaction.date.ToShortDateString()}\t{transaction.amount}\t{balance}\t\t{transaction.note}");
        }
        return report.ToString();
    }

    public virtual void PerformMonthEndTransactions() { }
}