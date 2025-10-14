using System;

namespace BankAccountApp
{
    /// <summary>
    /// Represents a single transaction record (deposit, withdrawal, transfer).
    /// </summary>
    public class Transaction
    {
        public DateTime Date { get; set; }
        public string Type { get; set; } = "";
        public decimal Amount { get; set; }
        public string? Note { get; set; }

        public override string ToString()
        {
            return $"{Date:G} - {Type} - {Amount:C2} {(string.IsNullOrEmpty(Note) ? "" : $"({Note})")}";
        }
    }
}
