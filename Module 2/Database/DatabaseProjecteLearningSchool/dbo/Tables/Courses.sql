CREATE TABLE [dbo].[Courses] (
    [CourseId]     INT             IDENTITY (1, 1) NOT NULL,
    [Capacity]     INT             NOT NULL,
    [Schedule]     NVARCHAR (1000) NOT NULL,
    [LevelId]      INT             NOT NULL,
    [TeacherId]    INT             NOT NULL,
    [LanguageId]   INT             NOT NULL,
    [Duration]     NVARCHAR (1000) NOT NULL,
    [Price]        INT             NOT NULL,
    [Description]  NVARCHAR (1000) NOT NULL,
    [Prerequisite] INT             NOT NULL,
    [AgeId]        INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([CourseId] ASC),
    CHECK ([Capacity]>(0)),
    FOREIGN KEY ([AgeId]) REFERENCES [dbo].[AgeRange] ([AgeId]),
    FOREIGN KEY ([LanguageId]) REFERENCES [dbo].[Language] ([LanguageId]),
    FOREIGN KEY ([LevelId]) REFERENCES [dbo].[Level] ([LevelId]),
    FOREIGN KEY ([Prerequisite]) REFERENCES [dbo].[Level] ([LevelId]),
    FOREIGN KEY ([TeacherId]) REFERENCES [dbo].[Teachers] ([TeacherId]) ON UPDATE CASCADE
);


GO

