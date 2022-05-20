using BankApplication;

public class InterestEarningAccount : BankAccount{
    public InterestEarningAccount(string name, decimal amount) : base(name, amount) { }

    public override void PerfomeMonthEndTransactions(){
        if(balance > 500m){
            decimal interest = balance * 0.05m;
            MakeDeposit(interest, DateTime.Now, "Apply Monthly Interest");
        }
    } 
}