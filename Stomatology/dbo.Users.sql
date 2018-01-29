CREATE TABLE [dbo].[Users] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Login]    VARCHAR (14)  NOT NULL,
    [Name]     NVARCHAR (50) NULL,
    [Birthday] NCHAR (12)    NULL,
    [Number]   NVARCHAR (50) NULL,
    [Adress]   NVARCHAR (50) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Number] ASC),
    UNIQUE NONCLUSTERED ([Login] ASC)
);

