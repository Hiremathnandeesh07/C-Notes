-- insert
CREATE PROCEDURE sp_AddEmployee
    @Name VARCHAR(100),
    @Salary DECIMAL(10,2),
    @DeptName VARCHAR(100)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION

        INSERT INTO tblEmployees(Name, Salary, DeptName)
        VALUES (@Name, @Salary, @DeptName)

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
        THROW
    END CATCH
END


--get all
CREATE PROCEDURE sp_GetAllEmployees
AS
BEGIN
    SELECT * FROM tblEmployees
END

-- get by id
CREATE PROCEDURE sp_GetEmployeeById
    @Id INT
AS
BEGIN
    SELECT * FROM tblEmployees WHERE Id = @Id
END

-- update salary

CREATE PROCEDURE sp_UpdateSalary
    @Id INT,
    @Salary DECIMAL(10,2)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION

        UPDATE tblEmployees
        SET Salary = @Salary
        WHERE Id = @Id

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
        THROW
    END CATCH
END


-- delete


CREATE PROCEDURE sp_DeleteEmployee
    @Id INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION

        DELETE FROM tblEmployees WHERE Id = @Id

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
        THROW
    END CATCH
END


