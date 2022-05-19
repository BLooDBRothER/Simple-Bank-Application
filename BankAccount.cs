namespace BankApplication;

public class BankAccount{
    private static int accountNumberSeed = 1234567890;
    public string accontNumber {get; set;}
    public string name {get; set;}
    public decimal balance {get; set;}
    public BankAccount(string name, decimal initialBalance){
        this.accontNumber = accountNumberSeed.ToString();
        accountNumberSeed++;
        this.name = name;
        this.balance = initialBalance;
    }
    public void MakeDeposit(decimal amount){

    }
    public void MakeWithdrawal(decimal amoung){

    }
}