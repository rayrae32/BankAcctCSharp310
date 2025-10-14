# Overview

As a growing software engineer, I’m focused on strengthening my backend programming and data management skills by building structured, real-world applications.

This project — **Bank Account Console App** — is a C# program that allows users to manage multiple bank accounts. It supports creating accounts, depositing, withdrawing, transferring funds, and viewing account statements. The program also demonstrates **data persistence** using JSON files, ensuring that account data is saved and loaded between sessions.

My purpose for creating this software is to gain hands-on experience with object-oriented programming (OOP) in C#, file handling, and serialization. I also practiced writing reusable, modular classes and using lists to manage dynamic data structures.




# Development Environment

**Tools Used**
- Visual Studio Code as the main code editor  
- .NET 8 SDK for compiling and running the C# program  
- Git & GitHub for version control and publishing  
- JSON files for storing persistent data  

**Programming Language**
- C# (Object-Oriented Programming with Classes, Lists, and File I/O)

---

# Useful Websites

* [Microsoft Learn – C# Fundamentals](https://learn.microsoft.com/en-us/dotnet/csharp/)
* [W3Schools – C# Tutorial](https://www.w3schools.com/cs/index.php)
* [JSON.org – Understanding JSON Format](https://www.json.org/)
* [GitHub Docs – Using Git with VS Code](https://docs.github.com/)
* [Markdown Guide](https://www.markdownguide.org/cheat-sheet/)

---

# Example JSON File

```json
[
  {
    "AccountNumber": "001",
    "Owner": "Rachel Ukpabi",
    "Balance": 500.00,
    "Transactions": [
      {
        "Date": "2025-10-14T10:35:00",
        "Type": "Deposit",
        "Amount": 500.00,
        "Note": "Initial deposit"
      },
      {
        "Date": "2025-10-14T12:00:00",
        "Type": "Withdrawal",
        "Amount": 100.00,
        "Note": "ATM cash"
      }
    ]
  },
  {
    "AccountNumber": "002",
    "Owner": "David Green",
    "Balance": 250.00,
    "Transactions": [
      {
        "Date": "2025-10-14T11:00:00",
        "Type": "Deposit",
        "Amount": 250.00,
        "Note": "First deposit"
      },
      {
        "Date": "2025-10-14T15:00:00",
        "Type": "Transfer In",
        "Amount": 100.00,
        "Note": "From Account 001"
      }
    ]
  }
]



Run the project using:
```bash
dotnet run
