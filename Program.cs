using System;
using BankApplication;

var account = new BankAccount("Arul", 5000m);

Console.WriteLine($"Acoount no: {account.accontNumber}\nname: {account.name}\nBalance: {account.balance}");