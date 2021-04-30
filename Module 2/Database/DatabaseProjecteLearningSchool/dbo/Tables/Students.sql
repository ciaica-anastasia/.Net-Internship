CREATE TABLE [dbo].[Students] (
    [StudentId]              INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]              NVARCHAR (500) NOT NULL,
    [LastName]               NVARCHAR (500) NOT NULL,
    [PhoneNumber]            NVARCHAR (500) NOT NULL,
    [Email]                  NVARCHAR (500) NOT NULL,
    [LevelId]                INT            NOT NULL,
    [BirthDate]              DATE           NOT NULL,
    [EnrollmentDate]         DATE           DEFAULT (getdate()) NOT NULL,
    [Password]               NVARCHAR (500) NOT NULL,
    [StudentOverallStatusId] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([StudentId] ASC),
    CHECK ([Email] like '%@%'),
    CHECK (NOT [PhoneNumber] like '%[^0-9]%'),
    FOREIGN KEY ([LevelId]) REFERENCES [dbo].[Level] ([LevelId]),
    FOREIGN KEY ([StudentOverallStatusId]) REFERENCES [dbo].[StudentOverallStatus] ([StudentOverallStatusId]),
    UNIQUE NONCLUSTERED ([Email] ASC),
    UNIQUE NONCLUSTERED ([PhoneNumber] ASC)
);


GO

