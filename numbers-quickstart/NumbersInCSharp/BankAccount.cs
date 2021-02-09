using System;
using System.Collections.Generic;

namespace classes
{
	public class BankAccount
	{
		private readonly decimal minimumBalance;
		public int accountNumberSeed {get;}
		public string Number {get;}
		public string Owner {get; set;}
		private List<Transaction> allTransactions = new List<Transaction>();
		public decimal Balance
		{
			get
			{
				decimal balance = 0;
				foreach(var item in allTransactions)
				{
					balance += item.Amount;
				}

				return balance;
			}
		}

		public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
		{
			this.Number = accountNumberSeed.ToString();
			accountNumberSeed++;

			this.Owner = name;
			this.minimumBalance = minimumBalance;
			if (initialBalance > 0)
				MakeDeposit(initialBalance, DateTime.Now, "initial balance");
		}

		public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) {}

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
			if(amount <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be postiive");
			}
			if (Balance - amount < 0)
			{
				throw new InvalidOperationException("Not enough funds");
			}
			var withdrawal = new Transaction(-amount, date, note);
			allTransactions.Add(withdrawal);
		}

		public string getAccountHistory()
		{
			var report = new System.Text.StringBuilder();

			decimal balance = 0;
			report.AppendLine("Date\t\tAmount\tBalance\tNote");
			foreach(var item in allTransactions)
			{
				balance += item.Amount;
				report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
			}
			return report.ToString();
		}

		public virtual void PerformMonthEndTransaction() {}
	}

	public class InterestEarningAccount : BankAccount
	{
		public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance)
		{

		}

        public override void PerformMonthEndTransaction()
        {
            if (Balance > 500m)
			{
				var interest = Balance * 0.05m;
				MakeDeposit(interest, DateTime.Now, "apply monthly interest");
			}
        }
    
	}

	public class LineOfCreditAccount : BankAccount
	{
		public LineOfCreditAccount(string name, decimal initialBalance) : base(name, initialBalance)
		{

		}

        public override void PerformMonthEndTransaction()
        {
            if (Balance < 0)
			{
				var interest = -Balance * 0.07m;
				MakeWithdrawal(interest, DateTime.Now, "charge monthly interest");
			}
        }
    
	}

	public class GiftCardAccount : BankAccount
	{
		private decimal _monthlyDeposit = 0m;
		public GiftCardAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0) : base(name, initialBalance)
			=> _monthlyDeposit = monthlyDeposit;

        public override void PerformMonthEndTransaction()
        {
            if (_monthlyDeposit != 0)
			{
				MakeDeposit(_monthlyDeposit, DateTime.Now, "Add monthly deposit");
			}
        }
    
	}

	public class Transaction
	{
		public decimal Amount {get;}
		public DateTime Date {get;}
		public string Notes{get;}

		public Transaction(decimal amount, DateTime date, string note)
		{
			this.Amount = amount;
			this.Date = date;
			this.Notes = note;
		}
	}
}
