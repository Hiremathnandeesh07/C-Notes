CREATE DATABASE Hospital_Management_DB
USE Hospital_Management_DB


-- Creating Table 
-- 1. Patient's Table 
CREATE TABLE Patients
(
 PatientCode INT PRIMARY KEY IDENTITY(1000,1),
 FullName VARCHAR(100) NOT NULL,
 DOB DATE NOT NULL,
 Gender VARCHAR(10) NOT NULL,
 Phone VARCHAR(15) UNIQUE NOT NULL,
 Email VARCHAR(100)  NULL,
 IsActive BIT DEFAULT 1 NOT NULL,
 CreatedAt DATETIME DEFAULT GETDATE(),
 UpdatedAt DATETIME NULL
)


--2. Doctor's Table
CREATE TABLE Doctors
(
 DoctorCode INT PRIMARY KEY IDENTITY(100,1),
 FullName VARCHAR(100) NOT NULL,
 Specialization VARCHAR(100) NOT NULL,
 Phone VARCHAR(15) UNIQUE NOT NULL,
 ConsultationFee DECIMAL(10,2) NOT NULL CHECK(ConsultationFee > 0),
 IsAvailable BIT DEFAULT 1 NOT NULL,
 CreatedAt DATETIME DEFAULT GETDATE(),
 UpdatedAt DATETIME NULL
)

--3. Appoitment's Tabel
CREATE TABLE Appointments
(
 AppointmentId INT PRIMARY KEY IDENTITY(1,1),
 PatientCode INT NOT NULL,
 DoctorCode INT  NOT NULL,
 AppointmentDate DATETIME NOT NULL,
 AppointmentStatus VARCHAR(15) NOT NULL DEFAULT 'Scheduled'
 CHECK(AppointmentStatus IN ('Scheduled','Completed','Cancelled')),
 CancelledAt DATETIME NULL,
 CreatedAt DATETIME DEFAULT GETDATE(),
 CONSTRAINT FK_Appointment_Patient
 FOREIGN KEY(PatientCode) 

 REFERENCES Patients(PatientCode),
 CONSTRAINT FK_Appointment_dOCTOR

 FOREIGN KEY(DoctorCode)
 REFERENCES Doctors(DoctorCode)


)



-- PATIENTS SAMPLE DATA

INSERT INTO Patients
(FullName, DOB, Gender, Phone, Email)
VALUES
('Anirudh Patil', '2003-05-10', 'Male', '9876500001', 'anirudh@gmail.com'),

('Rahul Sharma', '1999-08-14', 'Male', '9876500002', 'rahul@gmail.com'),

('Sneha Reddy', '2001-11-20', 'Female', '9876500003', 'sneha@gmail.com'),

('Priya Nair', '1998-03-25', 'Female', '9876500004', 'priya@gmail.com'),

('Kiran Kumar', '2000-07-12', 'Male', '9876500005', 'kiran@gmail.com');


-- DOCTORS SAMPLE DATA


INSERT INTO Doctors
(FullName, Specialization, Phone, ConsultationFee)
VALUES
('Dr. Rajesh', 'Cardiology', '9000000001', 800.00),

('Dr. Meena', 'Neurology', '9000000002', 1200.00),

('Dr. Arjun', 'Orthopedics', '9000000003', 700.00),

('Dr. Kavya', 'Dermatology', '9000000004', 500.00),

('Dr. Vikram', 'Pediatrics', '9000000005', 600.00);



-- APPOINTMENTS SAMPLE DATA

INSERT INTO Appointments
(PatientCode, DoctorCode, AppointmentDate, AppointmentStatus)
VALUES
(1000, 100, '2026-05-30 10:00:00', 'Scheduled'),

(1001, 101, '2026-05-30 11:00:00', 'Completed'),

(1002, 102, '2026-05-31 09:30:00', 'Scheduled'),

(1003, 103, '2026-06-01 02:00:00', 'Cancelled'),

(1004, 104, '2026-06-02 04:30:00', 'Scheduled');







   
-- patient queries
--ADDING PATIENT

CREATE PROCEDURE sp_AddPatient
(
    @FullName VARCHAR(100),
    @DOB DATE,
    @Gender VARCHAR(10),
    @Phone VARCHAR(15),
    @Email VARCHAR(100)
)
AS
BEGIN
    BEGIN TRY

        BEGIN TRANSACTION;

        INSERT INTO Patients
        (
            FullName,
            DOB,
            Gender,
            Phone,
            Email,
            IsActive,
            CreatedAt,
            UpdatedAt
        )
        VALUES
        (
            @FullName,
            @DOB,
            @Gender,
            @Phone,
            @Email,
            1,
            GETDATE(),
            GETDATE()
        );

        COMMIT;

    END TRY

    BEGIN CATCH

        IF @@TRANCOUNT > 0
            ROLLBACK;

        THROW;

    END CATCH
END


-- UPDATE PATIENT
CREATE PROCEDURE sp_UpdatePatient
(
    @PatientCode INT,
    @FullName VARCHAR(100) = NULL,
    @DOB DATE = NULL,
    @Gender VARCHAR(10) = NULL,
    @Phone VARCHAR(15) = NULL,
    @Email VARCHAR(100) = NULL
)
AS
BEGIN
    BEGIN TRY

        BEGIN TRANSACTION;

        UPDATE Patients
        SET
            FullName = ISNULL(NULLIF(@FullName, ''), FullName),

            DOB = ISNULL(@DOB, DOB),

            Gender = ISNULL(NULLIF(@Gender, ''), Gender),

            Phone = ISNULL(NULLIF(@Phone, ''), Phone),

            Email = ISNULL(NULLIF(@Email, ''), Email),

            UpdatedAt = GETDATE()

        WHERE PatientCode = @PatientCode;

        IF @@ROWCOUNT = 0
        BEGIN
            THROW 50001, 'Patient not found', 1;
        END

        COMMIT;

    END TRY

    BEGIN CATCH

      
            ROLLBACK;

        THROW;

    END CATCH
END


-- DEACTIVATE PATIENT
CREATE PROCEDURE sp_DeactivatePatient
    @PatientCode INT
AS
BEGIN
    BEGIN TRY

        BEGIN TRANSACTION;

        UPDATE Patients
        SET
            IsActive = 0,
            UpdatedAt = GETDATE()
        WHERE PatientCode = @PatientCode
          AND IsActive = 1;

        IF @@ROWCOUNT = 0
        BEGIN
            THROW 50002, 'Patient not found or already deactivated', 1;
        END

        COMMIT;

    END TRY

    BEGIN CATCH

        IF @@TRANCOUNT > 0
            ROLLBACK;

        THROW;

    END CATCH
END



--GET ALL PATIENTS

CREATE PROCEDURE sp_GetAllPatients
AS
BEGIN
    BEGIN TRY

        SELECT *
    FROM Patients
    WHERE IsActive = 1;

    END TRY

    BEGIN CATCH
        THROW;
    END CATCH
END

