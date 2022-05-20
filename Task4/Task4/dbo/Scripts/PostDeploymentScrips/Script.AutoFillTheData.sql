/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
IF NOT EXISTS (SELECT * FROM Class)
BEGIN
    SET IDENTITY_INSERT [dbo].[Class] ON
    INSERT INTO [dbo].[Class] ([Id], [Number], [Letter]) VALUES (1, 11, N'A')
    INSERT INTO [dbo].[Class] ([Id], [Number], [Letter]) VALUES (2, 10, N'B')
    INSERT INTO [dbo].[Class] ([Id], [Number], [Letter]) VALUES (3, 9, N'C')
    INSERT INTO [dbo].[Class] ([Id], [Number], [Letter]) VALUES (4, 11, N'B')
    SET IDENTITY_INSERT [dbo].[Class] OFF
END

IF NOT EXISTS (SELECT * FROM Subject)
BEGIN
    SET IDENTITY_INSERT [dbo].[Subject] ON
    INSERT INTO [dbo].[Subject] ([Id], [Name]) VALUES (1, N'Math')
    INSERT INTO [dbo].[Subject] ([Id], [Name]) VALUES (2, N'Biology')
    INSERT INTO [dbo].[Subject] ([Id], [Name]) VALUES (3, N'Chemistry')
    INSERT INTO [dbo].[Subject] ([Id], [Name]) VALUES (4, N'Phisics')
    SET IDENTITY_INSERT [dbo].[Subject] OFF
END

IF NOT EXISTS (SELECT * FROM Student)
BEGIN
    SET IDENTITY_INSERT [dbo].[Student] ON
    INSERT INTO [dbo].[Student] ([Id], [FirstName], [LastName], [PhoneNumber], [Address], [ClassId]) VALUES (1, N'IVAN', N'Ivanov', N'375293455495', N'Minsk', 1)
    INSERT INTO [dbo].[Student] ([Id], [FirstName], [LastName], [PhoneNumber], [Address], [ClassId]) VALUES (2, N'VASYA', N'Vasiliev', N'375291111111', N'Brest', 2)
    INSERT INTO [dbo].[Student] ([Id], [FirstName], [LastName], [PhoneNumber], [Address], [ClassId]) VALUES (3, N'VLAD', N'Vladimtsev', N'375222222222', N'Gomel', 3)
    INSERT INTO [dbo].[Student] ([Id], [FirstName], [LastName], [PhoneNumber], [Address], [ClassId]) VALUES (4, N'PETYA', N'Petrov', N'375241111111', N'Gomel', 1)
    SET IDENTITY_INSERT [dbo].[Student] OFF
END

IF NOT EXISTS (SELECT * FROM ClassSubject)
BEGIN
    SET IDENTITY_INSERT [dbo].[ClassSubject] ON
    INSERT INTO [dbo].[ClassSubject] ([Id], [ClassId], [SubjectId]) VALUES (1, 1, 1)
    INSERT INTO [dbo].[ClassSubject] ([Id], [ClassId], [SubjectId]) VALUES (2, 2, 2)
    INSERT INTO [dbo].[ClassSubject] ([Id], [ClassId], [SubjectId]) VALUES (3, 3, 3)
    INSERT INTO [dbo].[ClassSubject] ([Id], [ClassId], [SubjectId]) VALUES (4, 4, 1)
    SET IDENTITY_INSERT [dbo].[ClassSubject] OFF
END