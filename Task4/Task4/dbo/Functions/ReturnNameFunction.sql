CREATE FUNCTION [dbo].[ReturnNameFunction]
(
	@Id		INT
)
RETURNS VARCHAR(101)
AS
BEGIN
	DECLARE @FirstName VARCHAR(50), @LastName VARCHAR(50)
	SELECT @FirstName = FirstName, @LastName = LastName FROM Student
	WHERE Id = @Id

	RETURN @FirstName + ' ' + @LastName
END
