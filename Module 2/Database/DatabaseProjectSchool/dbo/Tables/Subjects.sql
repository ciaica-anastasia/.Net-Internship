CREATE TABLE [dbo].[Subjects] (
    [SubjectID] INT            NOT NULL,
    [Name]      NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([SubjectID] ASC),
    FOREIGN KEY ([SubjectID]) REFERENCES [dbo].[Teachers] ([TeacherID])
);


GO

