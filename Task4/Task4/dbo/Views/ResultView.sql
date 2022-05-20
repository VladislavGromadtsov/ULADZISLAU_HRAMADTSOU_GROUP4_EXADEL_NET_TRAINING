CREATE VIEW [dbo].[ResultView]
	AS
	SELECT [s].[FirstName], [s].[LastName], [s].[PhoneNumber],
		[s].[Address], [c].[Number], [c].[Letter]
	FROM dbo.Student AS s
	JOIN dbo.Class as c
	ON s.ClassId = c.Id
