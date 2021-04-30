CREATE TABLE [dbo].[StudentTeacherRelation] (
    [StudentID] INT NOT NULL,
    [TeacherID] INT NOT NULL,
    FOREIGN KEY ([StudentID]) REFERENCES [dbo].[Students] ([StudentID]),
    FOREIGN KEY ([TeacherID]) REFERENCES [dbo].[Teachers] ([TeacherID]),
    UNIQUE NONCLUSTERED ([StudentID] ASC, [TeacherID] ASC)
);


GO

