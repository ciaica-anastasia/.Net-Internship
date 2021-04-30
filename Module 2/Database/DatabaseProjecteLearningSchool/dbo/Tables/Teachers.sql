CREATE TABLE [dbo].[Teachers] (
    [TeacherId]   INT             IDENTITY (1, 1) NOT NULL,
    [Email]       NVARCHAR (500)  NOT NULL,
    [FirstName]   NVARCHAR (500)  NOT NULL,
    [LastName]    NVARCHAR (500)  NOT NULL,
    [PhoneNumber] NVARCHAR (500)  NOT NULL,
    [Description] NVARCHAR (1000) NOT NULL,
    PRIMARY KEY CLUSTERED ([TeacherId] ASC),
    CHECK ([Email] like '%@%'),
    CHECK (NOT [PhoneNumber] like '%[^0-9]%'),
    UNIQUE NONCLUSTERED ([Email] ASC),
    UNIQUE NONCLUSTERED ([PhoneNumber] ASC)
);


GO

