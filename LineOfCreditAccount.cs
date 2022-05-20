using BankApplication;

public class LineOfCreditAccount : BankAccount{
    public LineOfCreditAccount(string name, decimal amount) : base(name, amount){}

    public override void PerfomeMonthEndTransactions()
    {
        if(balance < 0){
            decimal charge = -balance * 0.07m;
            MakeWithdrawal(charge, DateTime.Now, "Charege Monthly Interest");
        }
    }
}