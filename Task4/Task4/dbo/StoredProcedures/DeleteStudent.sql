CREATE PROCEDURE [dbo].[DeleteStudent]
	@Id					INT,
	@Msg				nvarchar(MAX) = NULL OUTPUT
AS
	BEGIN TRY
		Delete Student
		WHERE Id = @Id

		SET @Msg='Student Deleted'
	END TRY

	BEGIN CATCH
		SET @Msg=ERROR_MESSAGE()
	END CATCH

GO