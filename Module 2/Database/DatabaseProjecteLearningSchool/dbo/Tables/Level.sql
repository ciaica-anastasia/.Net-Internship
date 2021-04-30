CREATE TABLE [dbo].[Level] (
    [LevelId] INT            IDENTITY (1, 1) NOT NULL,
    [Level]   NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([LevelId] ASC),
    CHECK ([Level]='Proficiency' OR [Level]='Advanced' OR [Level]='Upper-Intermediate' OR [Level]='Pre-Intermediate' OR [Level]='Intermediate' OR [Level]='Elementary' OR [Level]='Beginner'),
    UNIQUE NONCLUSTERED ([Level] ASC)
);


GO

