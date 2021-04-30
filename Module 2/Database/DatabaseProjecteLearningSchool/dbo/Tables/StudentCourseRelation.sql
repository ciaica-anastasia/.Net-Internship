CREATE TABLE [dbo].[StudentCourseRelation] (
    [StudentId]             INT NOT NULL,
    [CourseId]              INT NOT NULL,
    [StudentCourseStatusId] INT NOT NULL,
    [Approved]              BIT NOT NULL,
    PRIMARY KEY CLUSTERED ([StudentId] ASC, [CourseId] ASC),
    FOREIGN KEY ([CourseId]) REFERENCES [dbo].[Courses] ([CourseId]) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY ([StudentCourseStatusId]) REFERENCES [dbo].[StudentCourseStatus] ([StudentCourseStatusId]),
    FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Students] ([StudentId]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO

