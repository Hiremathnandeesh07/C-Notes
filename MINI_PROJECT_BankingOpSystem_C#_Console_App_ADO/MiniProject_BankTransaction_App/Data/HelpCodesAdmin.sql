CREATE DATABASE BankDB_MiniProject_C#_ADO_Server

USE BankDB_MiniProject_C#_ADO_Server





SELECT name 
FROM sys.databases;

-- customers table
CREATE TABLE Customers (
    CustomerId INT IDENTITY PRIMARY KEY,
    FullName VARCHAR(100),
    Gender VARCHAR(10),
    MobileNumber VARCHAR(15),
    Email VARCHAR(100),
    Address VARCHAR(200),
    AadhaarNumber VARCHAR(20),
    AccountType VARCHAR(50),
    AccountNumber BIGINT UNIQUE,
    Password VARCHAR(100),
    Balance DECIMAL(10,2) DEFAULT 100,
    AccountStatus VARCHAR(20) DEFAULT 'ACTIVE',
    CreatedDate DATETIME DEFAULT GETDATE()
);

drop table Customers


select * from customers
-- admin table

CREATE TABLE Admins (
    AdminId INT PRIMARY KEY,
    UserName VARCHAR(50),
    Password VARCHAR(50)
);

INSERT INTO Admins VALUES (1,'admin','admin123');
    

-- transactions table

CREATE TABLE Transactions (
    TransactionId INT IDENTITY PRIMARY KEY,

    AccountNumber BIGINT,
    
    TransactionType VARCHAR(50),
    Amount DECIMAL(10,2),
    TransactionDate DATETIME DEFAULT GETDATE(),
    BalanceAfterTransaction DECIMAL(10,2),

    CONSTRAINT FK_Transactions_Customers
    FOREIGN KEY (AccountNumber)
    REFERENCES Customers(AccountNumber)
);

drop table Transactions


-- admin login

CREATE PROCEDURE sp_AdminLogin
@UserName varchar(50),
@Password varchar(50)
AS
BEGIN
    SELECT COUNT(*) FROM Admins
    WHERE username=@UserName and password=@Password
END;


exec sp_adminlogin 'admin','admin123'

drop procedure sp_AdminLogin

--- add new customer

CREATE PROCEDURE sp_RegisterCustomer
    @FullName VARCHAR(100),
    @Gender VARCHAR(10),
    @MobileNumber VARCHAR(15),
    @Email VARCHAR(100),
    @Address VARCHAR(200),
    @AadhaarNumber VARCHAR(20),
    @AccountType VARCHAR(50),
   
    @Password VARCHAR(100)
    
    
    
AS
BEGIN
    INSERT INTO Customers
    (FullName, gender,mobileNumber,email, Address, AadhaarNumber, AccountType, Password, AccountNumber, Balance, AccountStatus)
    VALUES
    (@FullName,@gender, @MobileNumber,@email, @Address, @AadhaarNumber, @AccountType, @Password,
     ABS(CHECKSUM(NEWID())) % 1000000000, 0, 'Active');
END
    
    
    select * from customers
exec sp_RegisterCustomer 'nandeesh','male','7248374878','ader@gmail.com','hydrabad',
                            '8989878987','Savings','nandeesh123'

        
-- login customer
create PROCEDURE sp_CustomerLogin
    @MobileNumber BIGINT,
    @Password VARCHAR(50)
AS
BEGIN
    SELECT fullname,accountNumber
    from customers
    where MobileNumber=@MobileNumber AND Password=@Password;
END


exec sp_CustomerLogin '7248374878','nandeesh123'



-- update customer

create procedure sp_UpdateCustomer
 @AccountNumber BIGINT ,
  
    @MobileNumber VARCHAR(15) = NULL,
    @Email VARCHAR(100) = NULL,
    @Address VARCHAR(200) = NULL,
  
    @AccountType VARCHAR(50) = NULL,
   
    @AccountStatus VARCHAR(20) = NULL
    
AS
BEGIN
   UPDATE Customers
SET 
    MobileNumber = ISNULL(NULLIF(@MobileNumber, ''), MobileNumber),
    Email        = ISNULL(NULLIF(@Email, ''), Email),
    Address      = ISNULL(NULLIF(@Address, ''), Address),
    AccountType  = ISNULL(NULLIF(@AccountType, ''), AccountType),
    AccountStatus= ISNULL(NULLIF(@AccountStatus, ''), AccountStatus)
WHERE AccountNumber = @AccountNumber;
END



EXEC sp_UpdateCustomer
    @mobilenumber = '9999999999', 
    @accountNumber = '768963911'


-- delete account
CREATE PROCEDURE sp_DeleteCustomer
@AccountNumber BIGINT
AS
BEGIN
    UPDATE Customers
    SET AccountStatus = 'Closed'
    WHERE AccountNumber = @AccountNumber;
end

-- view all customers

CREATE PROCEDURE sp_ViewAllCustomers
AS
BEGIN
    SELECT * FROM Customers
END


exec sp_ViewAllCustomers

-- search cutomer by account number
CREATE PROCEDURE sp_SearchCustomerByAcNo
@AccountNumber BIGINT
AS
BEGIN
    SELECT * FROM Customers where AccountNumber=@AccountNumber;
END

-- search cutomer by account number
create PROCEDURE sp_SearchCustomerByMbNo
@AccountNumber VARCHAR(15)
AS
BEGIN
    SELECT * FROM Customers where AccountNumber=@AccountNumber;
END

-- view customers by account type

CREATE PROCEDURE sp_ViewCustomerByType
@AccountType VARCHAR(50)
AS
BEGIN
    SELECT * FROM customers where accountType=@AccountType;
END;


-- view transaction history
create PROCEDURE sp_ViewTransactionHistory
@AccountNumber BIGINT
AS
BEGIN
    SELECT * FROM Transactions
    
    where AccountNumber=@AccountNumber
END;


exec sp_ViewTransactionHistory 1000000011



exec sp_ViewTransactionHistory '1000000014'

-- freeze account
CREATE PROCEDURE sp_FreezeAccount
@AccountNumber BIGINT
AS
BEGIN
    UPDATE Customers set AccountType = 'Inactive'
    WHERE AccountNumber = @accountNumber
END;




