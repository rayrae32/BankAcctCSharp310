using System;
using System.Collections.Generic;

namespace BankAccountApp
{
    /// <summary>
    /// Represents a single customer account with balance and transaction history.
    /// </summary>
    public class Account
    {
        public string AccountNumber { get; set; } = "";
        public string Owner { get; set; } = "";
        public decimal Balance { get; set; }         public List<Transaction> Transactions { get; set; } = new();

        /// <summary>
        /// Deposits an amount into the account.
        /// </summary>
        public void Deposit(decimal amount, string? note = null)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be greater than zero.");
                return;
            }

            Balance += amount;
            Transactions.Add(new Transaction
            {
                Date = DateTime.Now,
                Type = "Deposit",
                Amount = amount,
                Note = note
            });
        }

        /// <summary>
        /// Withdraws an amount from the account if sufficient funds exist.
        /// </summary>
        public void Withdraw(decimal amount, string? note = null)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be greater than zero.");
                return;
            }

            if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds.");
                return;
            }

            Balance -= amount;
            Transactions.Add(new Transaction
            {
                Date = DateTime.Now,
                Type = "Withdrawal",
                Amount = amount,
                Note = note
            });
        }

        /// <summary>
        /// Prints a statement showing all transactions for the account.
        /// </summary>
        public void PrintStatement()
        {
            Console.WriteLine($"\n=== Statement for {Owner} ({AccountNumber}) ===");
            foreach (var t in Transactions)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine($"Current Balance: {Balance:C2}\n");
        }
    }
}
