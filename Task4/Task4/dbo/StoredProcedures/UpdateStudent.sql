CREATE PROCEDURE [dbo].[UpdateStudent]
	@Id					INT,
	@FirstName			nvarchar(50) = NULL,
	@LastName			nvarchar(50) = NULL,
	@PhoneNumber		nvarchar(15) = NULL,
	@Address			nvarchar(120) = NULL,
	@ClassId			INT = NULL,
	@Msg				nvarchar(MAX) = NULL OUTPUT
AS
	BEGIN TRY
		UPDATE Student
		SET 
			FirstName = ISNULL(@FirstName, FirstName),
			LastName = ISNULL(@LastName, LastName),
			PhoneNumber = ISNULL(@PhoneNumber, PhoneNumber),
			Address = ISNULL(@Address, Address),
			ClassId = ISNULL(@ClassId, ClassId)
		WHERE Id = @Id

		SET @Msg='Student Table Details Updated'
	END TRY

	BEGIN CATCH
		SET @Msg=ERROR_MESSAGE()
	END CATCH

GO