using BankApplication;

public class GiftCardAccount : BankAccount{
    private readonly decimal _monthlyDeposit = 0m;
    public GiftCardAccount(string name, decimal amount, decimal monthlyDeposit=0) : base(name, amount){
        _monthlyDeposit = monthlyDeposit;
    }

    public override void PerformMonthEndTransactions()
    {
        if(_monthlyDeposit != 0){
            MakeDeposit(_monthlyDeposit, DateTime.Now, "Add monthly deposit");
        }
    }
}