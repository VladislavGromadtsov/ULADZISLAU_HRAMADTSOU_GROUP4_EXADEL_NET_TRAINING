CREATE TRIGGER [AddStudentTrigger]
	ON [dbo].[Student]
	AFTER INSERT, UPDATE
	AS
	UPDATE Student
	SET FirstName = UPPER(FirstName)
	WHERE Id = (SELECT Id from inserted)