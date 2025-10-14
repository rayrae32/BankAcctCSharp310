using System;

namespace BankAccountApp
{
    class Program
    {
        static void Main()
        {
            Bank bank = new Bank();
            string filePath = Path.Combine(AppContext.BaseDirectory, "bank_data.json");
            bank.LoadFromFile(filePath);

            while (true)
            {
                Console.WriteLine("\n=== Bank Account Console App ===");
                Console.WriteLine("1) Create Account");
                Console.WriteLine("2) Deposit");
                Console.WriteLine("3) Withdraw");
                Console.WriteLine("4) Transfer");
                Console.WriteLine("5) View Statement");
                Console.WriteLine("6) List All Accounts");
                Console.WriteLine("7) Save & Exit");
                Console.Write("Select an option: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter owner name: ");
                        string owner = Console.ReadLine() ?? "";
                        Console.Write("Enter account number: ");
                        string number = Console.ReadLine() ?? "";
                        bank.CreateAccount(owner, number);
                        break;

                    case "2":
                        Console.Write("Enter account number: ");
                        string accNum = Console.ReadLine() ?? "";
                        var acc = bank.FindAccount(accNum);
                        if (acc == null) { Console.WriteLine("Account not found."); break; }
                        Console.Write("Enter amount to deposit: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal depAmt))
                        {
                            acc.Deposit(depAmt);
                            Console.WriteLine($"Deposited {depAmt:C2} to {acc.Owner}. New balance: {acc.Balance:C2}");
                        }
                        break;

                    case "3":
                        Console.Write("Enter account number: ");
                        string accNumW = Console.ReadLine() ?? "";
                        var accW = bank.FindAccount(accNumW);
                        if (accW == null) { Console.WriteLine("Account not found."); break; }
                        Console.Write("Enter amount to withdraw: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal withAmt))
                        {
                            accW.Withdraw(withAmt);
                            Console.WriteLine($"New balance: {accW.Balance:C2}");
                        }
                        break;

                    case "4":
                        Console.Write("Enter FROM account: ");
                        string from = Console.ReadLine() ?? "";
                        Console.Write("Enter TO account: ");
                        string to = Console.ReadLine() ?? "";
                        Console.Write("Enter amount: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal transAmt))
                            bank.Transfer(from, to, transAmt);
                        break;

                    case "5":
                        Console.Write("Enter account number: ");
                        string accNumS = Console.ReadLine() ?? "";
                        var accS = bank.FindAccount(accNumS);
                        if (accS == null) Console.WriteLine("Account not found.");
                        else accS.PrintStatement();
                        break;

                    case "6":
                        Console.WriteLine("\nAccounts:");
                        foreach (var a in bank.Accounts)
                            Console.WriteLine($"{a.Owner} - {a.AccountNumber} - {a.Balance:C2}");
                        break;

                    case "7":
                        bank.SaveToFile(filePath);
                        Console.WriteLine("Data saved. Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}