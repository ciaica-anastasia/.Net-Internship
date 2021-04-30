CREATE TABLE [dbo].[Students] (
    [StudentID]   INT           NOT NULL,
    [FirstName]   NVARCHAR (10) NOT NULL,
    [LastName]    NVARCHAR (10) NOT NULL,
    [PhoneNumber] INT           NOT NULL,
    [Email]       NVARCHAR (20) NOT NULL,
    [GradeID]     INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([StudentID] ASC),
    CHECK ([Email] like '%___@___%'),
    FOREIGN KEY ([GradeID]) REFERENCES [dbo].[Grades] ([GradeID]),
    UNIQUE NONCLUSTERED ([Email] ASC)
);


GO

