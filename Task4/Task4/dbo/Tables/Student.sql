CREATE TABLE [dbo].[Student]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [PhoneNumber] NVARCHAR(15) NULL, 
    [Address] NVARCHAR(120) NULL, 
    [ClassId] INT NOT NULL, 
    CONSTRAINT [FK_Student_Class] FOREIGN KEY ([ClassId]) REFERENCES [Class]([Id])
)

GO

CREATE INDEX [IX_Student_Column] ON [dbo].[Student] ([Column])
