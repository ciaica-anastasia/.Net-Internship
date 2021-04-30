CREATE TABLE [dbo].[Language] (
    [LanguageId]   INT            IDENTITY (1, 1) NOT NULL,
    [LanguageName] NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([LanguageId] ASC),
    UNIQUE NONCLUSTERED ([LanguageName] ASC)
);


GO

