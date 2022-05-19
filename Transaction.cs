namespace BankApplication;

public class Transaction{
    public decimal amount { get; set; }
    public DateTime date { get; set; }
    public string note { get; set; }

    public Transaction(decimal amount, DateTime date, string note){
        this.amount = amount;
        this.date = date;
        this.note = note;
    }
}