CREATE TABLE [dbo].[AgeRange] (
    [AgeId]    INT            IDENTITY (1, 1) NOT NULL,
    [AgeRange] NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([AgeId] ASC),
    CHECK ([AgeRange]='Adults' OR [AgeRange]='School' OR [AgeRange]='Preschool')
);


GO

