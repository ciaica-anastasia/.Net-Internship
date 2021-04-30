CREATE TABLE [dbo].[StudentCourseStatus] (
    [StudentCourseStatusId] INT            IDENTITY (1, 1) NOT NULL,
    [StudentCourseStatus]   NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([StudentCourseStatusId] ASC),
    CHECK ([StudentCourseStatus]='Frozen' OR [StudentCourseStatus]='Finished' OR [StudentCourseStatus]='In progress' OR [StudentCourseStatus]='Waiting for start'),
    UNIQUE NONCLUSTERED ([StudentCourseStatus] ASC)
);


GO

