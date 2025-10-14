using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace BankAccountApp
{
    /// <summary>
    /// Bank class that manages multiple accounts and persistence.
    /// </summary>
    public class Bank
    {
        public List<Account> Accounts { get; set; } = new();

        /// <summary>
        /// Creates a new account and adds it to the bank.
        /// </summary>
        public void CreateAccount(string owner, string accountNumber)
        {
            if (Accounts.Exists(a => a.AccountNumber == accountNumber))
            {
                Console.WriteLine("Account number already exists.");
                return;
            }

            Accounts.Add(new Account
            {
                Owner = owner,
                AccountNumber = accountNumber
            });
            Console.WriteLine($"Account for {owner} created successfully.");
        }

        /// <summary>
        /// Finds an account by account number.
        /// </summary>
        public Account? FindAccount(string accountNumber)
        {
            return Accounts.Find(a => a.AccountNumber == accountNumber);
        }

        /// <summary>
        /// Transfers money between two accounts.
        /// </summary>
        public void Transfer(string fromAcc, string toAcc, decimal amount)
        {
            var source = FindAccount(fromAcc);
            var destination = FindAccount(toAcc);

            if (source == null || destination == null)
            {
                Console.WriteLine("One or both accounts not found.");
                return;
            }

            if (source.Balance < amount)
            {
                Console.WriteLine("Insufficient funds for transfer.");
                return;
            }

            source.Withdraw(amount, $"Transfer to {toAcc}");
            destination.Deposit(amount, $"Transfer from {fromAcc}");
            Console.WriteLine($"Transferred {amount:C2} from {source.Owner} to {destination.Owner}.");
        }

        /// <summary>
        /// Saves all account data to a JSON file.
        /// </summary>
        public void SaveToFile(string filePath)
        {
            var json = JsonSerializer.Serialize(Accounts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        /// <summary>
        /// Loads all account data from a JSON file if it exists.
        /// </summary>
        public void LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath)) return;
            var json = File.ReadAllText(filePath);
            Accounts = JsonSerializer.Deserialize<List<Account>>(json) ?? new List<Account>();
        }
    }
}
