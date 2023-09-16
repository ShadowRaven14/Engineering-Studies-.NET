CREATE TABLE [dbo].[Category]
(
    [Id]    INT        IDENTITY (1, 1) NOT NULL,
    [shortName]  NCHAR (10) NOT NULL,
    [longName] NCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
