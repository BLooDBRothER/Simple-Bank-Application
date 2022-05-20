using System;
using BankApplication;

var account = new BankAccount("Arul", 5000m);

account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
account.MakeDeposit(100, DateTime.Now, "Friend paid me back");

Console.WriteLine(account.GetAccountBalance());

// * Uncomment the follwing thing to run the test
// Test for a negative initial balance

// BankAccount invalidAccount;
// try{
//     invalidAccount = new BankAccount("invalid", -55);
// }
// catch (ArgumentOutOfRangeException e)
// {
//     Console.WriteLine("Exception caught creating account with negative balance");
//     Console.WriteLine(e.ToString());
// }

// Test for a negative balance.

// try
// {
//     account.MakeWithdrawal(7500, DateTime.Now, "Attempt to overdraw");
// }
// catch (InvalidOperationException e)
// {
//     Console.WriteLine("Exception caught trying to overdraw");
//     Console.WriteLine(e.ToString());
// }