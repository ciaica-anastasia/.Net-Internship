CREATE TABLE [dbo].[StudentOverallStatus] (
    [StudentOverallStatusId] INT            IDENTITY (1, 1) NOT NULL,
    [StudentOverallStatus]   NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([StudentOverallStatusId] ASC),
    CHECK ([StudentOverallStatus]='Registered' OR [StudentOverallStatus]='Pending' OR [StudentOverallStatus]='Inactive' OR [StudentOverallStatus]='Active'),
    UNIQUE NONCLUSTERED ([StudentOverallStatus] ASC)
);


GO

