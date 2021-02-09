using System;
using System.Collections.Generic;

namespace classes
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Andrew", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

            account.MakeWithdrawal(500, DateTime.Now, "Rent Payment");
            account.MakeDeposit(100, DateTime.Now, "Friend payed back");

            Console.WriteLine(account.Balance);
            Console.WriteLine(account.getAccountHistory());

            BankAccount newAccount = new InterestEarningAccount("Andrew", 2000);
            newAccount.PerformMonthEndTransaction();
            Console.WriteLine(newAccount.Balance);
        }
    }
}
