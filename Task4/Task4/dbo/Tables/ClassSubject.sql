CREATE TABLE [dbo].[ClassSubject]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ClassId] INT NOT NULL, 
    [SubjectId] INT NOT NULL, 
    CONSTRAINT [FK_ClassSubject_Class] FOREIGN KEY ([ClassId]) REFERENCES [Class]([Id]), 
    CONSTRAINT [FK_ClassSubject_Subject] FOREIGN KEY ([SubjectId]) REFERENCES [Subject]([Id])
)
