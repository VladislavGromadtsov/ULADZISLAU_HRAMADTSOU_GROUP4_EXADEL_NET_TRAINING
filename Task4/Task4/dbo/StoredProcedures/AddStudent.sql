CREATE PROCEDURE [dbo].[AddStudent]
	@FirstName			nvarchar(50) = NULL,
	@LastName			nvarchar(50) = NULL,
	@PhoneNumber		nvarchar(15) = NULL,
	@Address			nvarchar(120) = NULL,
	@ClassId			INT,
	@Msg				nvarchar(MAX) = NULL OUTPUT
AS
	BEGIN TRY
		INSERT INTO Student
		(
		FirstName, LastName, PhoneNumber, Address, ClassId
		)
		VALUES
		(
		@FirstName, @LastName, @PhoneNumber, @Address, @ClassId
		)

		SET @Msg='Srudent Table Details Added'
	END TRY

	BEGIN CATCH
		SET @Msg=ERROR_MESSAGE()
	END CATCH

GO
		
