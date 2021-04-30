CREATE TABLE [dbo].[Teachers] (
    [TeacherID]   INT           NOT NULL,
    [FirstName]   NVARCHAR (10) NOT NULL,
    [LastName]    NVARCHAR (10) NOT NULL,
    [PhoneNumber] INT           NOT NULL,
    [Email]       NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([TeacherID] ASC),
    CHECK ([Email] like '%___@___%'),
    UNIQUE NONCLUSTERED ([Email] ASC)
);


GO

