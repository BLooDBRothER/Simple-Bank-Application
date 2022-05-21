using BankApplication;

public class LineOfCreditAccount : BankAccount{
    public LineOfCreditAccount(string name, decimal amount, decimal creditLimit) : base(name, amount, -creditLimit){}

    public override void PerformMonthEndTransactions()
    {
        if(balance < 0){
            decimal charge = -balance * 0.07m;
            MakeWithdrawal(charge, DateTime.Now, "Charege Monthly Interest");
        }
    }

    protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn) =>
        isOverdrawn
        ? new Transaction(-20, DateTime.Now, "Apply overdraft fee")
        : default;
}