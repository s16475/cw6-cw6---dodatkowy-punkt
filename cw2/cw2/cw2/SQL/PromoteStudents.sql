CREATE PROCEDURE PromoteStudents @Studies varchar(255), @Semester int
AS
BEGIN
	BEGIN TRAN
	
	DECLARE @IdStudies int = (SELECT IdStudy From Studies where Name=@Studies);
	IF @IdStudies IS NULL
		BEGIN
			ROLLBACK;
			SELECT 404;
		END
		
	DECLARE @OldIdEnrollment int = (Select IdEnrollment from Enrollment where IdStudy = @IdStudies AND Semester = @Semester);
	DECLARE @NewIdEnrollment int = (Select IdEnrollment from Enrollment where IdStudy = @IdStudies AND Semester = (@Semester+1));
		
		IF @NewIdEnrollment IS NULL
			BEGIN
				SET @NewIdEnrollment = (Select MAX(IdEnrollment) from Enrollment) + 1;
				INSERT INTO Enrollment(IdEnrollment, Semester, IdStudy, StartDate) VALUES(@NewIdEnrollment, @Semester + 1, @IdStudies, CURRENT_TIMESTAMP);
			END
		UPDATE Student
			SET Student.IdEnrollment = @NewIdEnrollment
			WHERE Student.IdEnrollment = @OldIdEnrollment;
		COMMIT
	SELECT * FROM Enrollment WHERE Enrollment.IdEnrollment = @NewIdEnrollment;
END
