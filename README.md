# 🏦 Bank Operating System — ADO.NET Console Application

A complete **Bank Management System** built using **C#, ADO.NET, SQL Server, and Stored Procedures**.  
This console-based application provides secure banking operations for both **Admins** and **Customers** with a clean layered architecture.

---

# ✨ Features

## 👨‍💼 Admin Functionalities

- ➕ Add Customer
- ✏️ Update Customer Details
- ❌ Delete Customer
- 📋 View All Customers
- 🔍 Search Customer By Account Number
- 🏦 View Customers By Account Type
- 📜 View Transaction History
- 🔒 Freeze Customer Account
- ✅ Activate Customer Account

---

## 👤 Customer Functionalities

- 🔐 Customer Login
- 💰 Deposit Money
- 💸 Withdraw Money
- 📊 Check Account Balance
- 🧾 Mini Statement
- 🔁 Fund Transfer
- 📝 Update Profile
- 🔑 Change Password
- ❌ Close Account

---

# 🛠️ Technologies Used

| Technology | Purpose |
|---|---|
| C# | Application Development |
| ADO.NET | Database Connectivity |
| SQL Server | Database Management |
| Stored Procedures | Secure Database Operations |
| .NET Framework | Runtime Environment |
| Console Application | User Interface |

---

# 📂 Project Structure

```text
BankOperatingSys_ADO.Net/
│
├── Models/
│   ├── Admin.cs
│   ├── Customer.cs
│   └── Transaction.cs
│
├── Data/
│   ├── DatabaseConnection.cs
│   └── HelpCodeSql.sql
│
├── Repository/
│   ├── AdminRepository.cs
│   └── CustomerRepository.cs
│
├── Services/
│   ├── AdminServices.cs
│   └── CustomerServices.cs
│
├── App.config
│
└── Program.cs
```

---

# 🗄️ Database Information

## 📌 Database Name

```sql
BankDB
```

---

# 📑 Main Tables

## 👥 Customers Table

| Column Name | Description |
|---|---|
| CustomerId | Unique Customer ID |
| FullName | Customer Full Name |
| Gender | Gender |
| MobileNumber | Contact Number |
| Email | Email Address |
| Address | Residential Address |
| AadhaarNumber | Aadhaar Identification |
| AccountType | Savings / Current |
| AccountNumber | Unique Bank Account Number |
| Password | Login Password |
| Balance | Current Account Balance |
| AccountStatus | Active / Frozen |

---

## 💳 Transactions Table

| Column Name | Description |
|---|---|
| TransactionId | Unique Transaction ID |
| SenderAccount | Sender Account Number |
| ReceiverAccount | Receiver Account Number |
| TransactionType | Deposit / Withdraw / Transfer |
| Amount | Transaction Amount |
| TransactionDate | Date & Time |
| BalanceAfterTransaction | Updated Balance |

---

# ⚙️ Stored Procedures

Stored Procedures are implemented for secure and optimized database operations.

### Implemented Procedures

- ✅ Customer Registration
- ✅ Deposit Money
- ✅ Withdraw Money
- ✅ Fund Transfer
- ✅ Balance Check
- ✅ Update Customer
- ✅ Delete Customer
- ✅ Transaction History
- ✅ Account Status Management

---

# 🚀 How To Run The Project

## 1️⃣ Clone Repository

```bash
git clone <repository-url>
```

---

## 2️⃣ Open Project

Open the solution file in **Visual Studio**.

---

## 3️⃣ Configure Connection String

Update the SQL Server connection string inside:

```text
App.config
```

### Example

```xml
<connectionStrings>
  <add name="BankDB"
       connectionString="Data Source=.;Initial Catalog=BankDB;Integrated Security=True"
       providerName="System.Data.SqlClient"/>
</connectionStrings>
```

---

## 4️⃣ Execute SQL Scripts

Run all SQL scripts and Stored Procedures in **SQL Server Management Studio (SSMS)**.

---

## 5️⃣ Run Application

Start the project from Visual Studio.

---

# 🔐 Security Features

- ✔️ Input Validation
- ✔️ Parameterized Queries
- ✔️ Stored Procedures
- ✔️ Exception Handling
- ✔️ Account Freeze / Activate Functionality

---

# 📈 Future Enhancements

- 🔒 Password Hashing
- 📧 Email Notifications
- 📱 SMS Alerts
- 💹 Interest Calculation
- 🖥️ GUI using WinForms/WPF
- 🌐 ASP.NET Web API Integration
- 🏦 Online Banking Features

---

# 📚 Learning Outcomes

This project helped in understanding:

- ADO.NET CRUD Operations
- SQL Server Stored Procedures
- SQL Transactions
- Repository Pattern
- Service Layer Architecture
- Console Application Design
- Exception Handling
- Database Connectivity

---

# 👨‍💻 Author

## Nandeesh Hiremath

---

# 📄 License

This project is developed for **learning and educational purposes**.

---

# ⭐ Support

If you found this project useful, consider giving it a ⭐ on GitHub.
