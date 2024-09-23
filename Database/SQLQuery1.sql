CREATE TABLE [dbo].[Registration] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Username] VARCHAR (MAX) NULL,
    [Password] VARCHAR (MAX) NULL,
    [Name] VARCHAR (MAX) NULL,
    [City] VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

