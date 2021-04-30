CREATE TABLE [dbo].[Grades] (
    [GradeID] INT          NOT NULL,
    [Letter]  NVARCHAR (2) DEFAULT ('A') NOT NULL,
    PRIMARY KEY CLUSTERED ([GradeID] ASC)
);


GO

