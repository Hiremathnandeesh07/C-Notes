USE BankDB_MiniProject_C#_ADO_Server

select * from Transactions

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

select * from Transactions


--- deposite
CREATE PROCEDURE sp_DepositAmount
(
    @AccountNumber BIGINT,
    @Amount DECIMAL(10,2)
)
AS
BEGIN
    BEGIN TRY

        BEGIN TRANSACTION;

        -- Update customer balance
        UPDATE Customers
        SET Balance = Balance + @Amount
        WHERE AccountNumber = @AccountNumber;

        IF @@ROWCOUNT = 0
            THROW 50001, 'Issue during balance update...', 1;

        -- Insert transaction history
        INSERT INTO Transactions
        (
            AccountNumber,
            TransactionType,
            Amount,
            TransactionDate,
            BalanceAfterTransaction
        )
        VALUES
        (
            @AccountNumber,
            'Deposit',
            @Amount,
            GETDATE(),
            (
                SELECT Balance
                FROM Customers
                WHERE AccountNumber = @AccountNumber
            )
        );

        IF @@ROWCOUNT = 0
            THROW 50002, 'Issue during adding transaction', 1;

        COMMIT TRANSACTION;

    END TRY

    BEGIN CATCH

        ROLLBACK TRANSACTION;

        THROW;

    END CATCH
END;

exec sp_DepositAmount 1000000011,10000;


-- check balance
CREATE PROCEDURE sp_CheckBalance
@AccountNumber BIGINT
AS
BEGIN
SELECT Balance from Customers where AccountNumber=@AccountNumber;
END;


-- withdraw amount
alter PROCEDURE sp_WithDrawAmount
(
@AccountNumber BIGINT,
@Amount DECIMAL(10,2)
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        

        -- updating the balance 
        update Customers set balance=balance-@Amount where AccountNumber=@AccountNumber;

         IF @@ROWCOUNT = 0
            THROW 50001, 'Issue during balance update...', 1;

        -- adding to transaction
         INSERT INTO Transactions
        (
            AccountNumber,
            TransactionType,
            Amount,
            TransactionDate,
            BalanceAfterTransaction
        )
        VALUES
        (
            @AccountNumber,
            'Withdraw',
            @Amount,
            GETDATE(),
            (
                SELECT Balance
                FROM Customers
                WHERE AccountNumber = @AccountNumber
            )
        );

         IF @@ROWCOUNT = 0
            THROW 50001, 'Issue during transaction row inserting...', 1;


        COMMIT TRANSACTION;
    END TRY

     BEGIN CATCH

        ROLLBACK TRANSACTION;

        THROW;

    END CATCH
END;

exec sp_WithDrawAmount 1000000011,1000


select * from Transactions


-- showing mini statement 
CREATE PROCEDURE sp_ShowMiniStatement
@AccountNumber BIGINT
AS
BEGIN
SELECT * FROM Transactions where AccountNumber=@AccountNumber
order by TransactionDate desc
END;

exec sp_ShowMiniStatement 1000000011



-- find transfer
CREATE PROCEDURE sp_FundTransfer
@FromAccountNumber BIGINT,
@ToAccountNumber BIGINT,
@Amount decimal(10,2)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        IF @FromAccountNumber NOT IN (select accountNumber from Customers)
            THROW 5001,'user account not exists',1;

        IF @ToAccountNumber NOT IN (select accountNumber from Customers)
            THROW 5001,'receiver account not exists',1;

        -- withdraw from sender
        EXEC sp_WithDrawAmount @FromAccountNumber,@Amount;

        -- deposit in the receiver account
        EXEC sp_DepositAmount @ToAccountNumber,@Amount;


        COMMIT TRANSACTION;
    END TRY

    BEGIN CATCH

    ROLLBACK TRANSACTION;
    THROW;

    END CATCH;

    
END;


exec sp_FundTransfer 196401774,1000000011,1000


 -- select * from Transactions where accountNumber = 1000000011 order by TransactionDate desc 


 -- change password

CREATE PROCEDURE sp_ChangePassword
 @AccountNumber BIGINT,
 @Password VARCHAR(100)
 AS
 BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
    update Customers set Password=@Password
    where AccountNumber=@AccountNumber;
        COMMIT TRANSACTION;
    END TRY

    BEGIN CATCH
    ROLLBACK TRANSACTION;
    THROW;
    END CATCH;
END;


exec sp_ChangePassword 1000000011,'rahul@111'