USE Hospital_Management_DB


select * from Appointments
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

sp_BookAppointment
sp_CancelAppointment
sp_GetUpcomingAppointments
sp_GetDoctorAppointments


-- book appointment
CREATE PROCEDURE sp_BookAppointment
(
    @PatientCode INT,
    @DoctorCode INT,
    @AppointmentDate DATETIME
)
AS
BEGIN
    BEGIN TRY

        BEGIN TRANSACTION;

        IF @AppointmentDate < GETDATE()
        BEGIN
            THROW 50001, 'Appointment date cannot be in the past', 1;
        END

        IF NOT EXISTS
        (
            SELECT 1
            FROM Doctors
            WHERE DoctorCode = @DoctorCode
              AND IsAvailable = 1
        )
        BEGIN
            THROW 50002, 'Doctor is unavailable', 1;
        END

        -- Appointment duration = 1 hour
        IF EXISTS
        (
            SELECT 1
            FROM Appointments
            WHERE DoctorCode = @DoctorCode
              AND AppointmentStatus = 'Scheduled'
              AND @AppointmentDate <
                    DATEADD(HOUR,1,AppointmentDate)
              AND DATEADD(HOUR,1,@AppointmentDate) >
                    AppointmentDate
        )
        BEGIN
            THROW 50003,
                  'Doctor already has an appointment during this time slot',
                  1;
        END

        INSERT INTO Appointments
        (
            PatientCode,
            DoctorCode,
            AppointmentDate,
            AppointmentStatus,
            CreatedAt
        )
        VALUES
        (
            @PatientCode,
            @DoctorCode,
            @AppointmentDate,
            'Scheduled',
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

-- cancel appointment
CREATE PROCEDURE sp_CancelAppointment
(
    @AppointmentId INT
)
AS
BEGIN
    BEGIN TRY

        BEGIN TRANSACTION;

        
        UPDATE Appointments
        SET
            AppointmentStatus = 'Cancelled',
            CancelledAt = GETDATE()
        WHERE AppointmentId = @AppointmentId
        AND AppointmentStatus = 'Scheduled';

        IF @@ROWCOUNT = 0
        BEGIN
            THROW 50002,
            'Appointment not found or already cancelled/completed',
            1;
        END

        COMMIT;

    END TRY

    BEGIN CATCH

        IF @@TRANCOUNT > 0
            ROLLBACK;

        THROW;

    END CATCH
END


-- get upcomming appointments
ALTER PROCEDURE sp_GetUpcomingAppointments
AS
BEGIN
    BEGIN TRY

        SELECT
            AppointmentId,
            PatientCode,
            DoctorCode,
            AppointmentDate,
            AppointmentStatus,
            CancelledAt
        FROM Appointments
        WHERE AppointmentDate >= GETDATE()
        AND AppointmentStatus = 'Scheduled'
        ORDER BY AppointmentDate;

    END TRY

    BEGIN CATCH

        THROW;

    END CATCH
END

-- get doctor appointments
CREATE PROCEDURE sp_GetDoctorAppointments
(
    @DoctorCode INT
)
AS
BEGIN
    BEGIN TRY

        SELECT
            AppointmentId,
            PatientCode,
            DoctorCode,
            AppointmentDate,
            AppointmentStatus,
            CancelledAt
        FROM Appointments
        WHERE DoctorCode = @DoctorCode
        ORDER BY AppointmentDate DESC;

    END TRY

    BEGIN CATCH

        THROW;

    END CATCH
END



-- get patients appointments


CREATE PROCEDURE sp_GetPatientAppointments
(
    @PatientCode INT
)
AS
BEGIN
    BEGIN TRY

        SELECT
            AppointmentId,
            PatientCode,
            DoctorCode,
            AppointmentDate,
            AppointmentStatus,
            CancelledAt
        FROM Appointments
        WHERE PatientCode=@PatientCode
        ORDER BY AppointmentDate DESC;

    END TRY

    BEGIN CATCH

        THROW;

    END CATCH
END



CREATE PROCEDURE sp_UpdateCompletedAppointments
AS
BEGIN
    BEGIN TRY

        UPDATE Appointments
        SET AppointmentStatus = 'Completed'
        WHERE AppointmentStatus = 'Scheduled'
          AND AppointmentDate < GETDATE();

    END TRY

    BEGIN CATCH

        THROW;

    END CATCH
END
GO