CREATE TABLE [dbo].[Policy] (
    [Id]     INT           IDENTITY (1, 1) NOT NULL,
    [PolicyName] NVARCHAR (50) NULL,
    [Allow] BIT NULL, 
    CONSTRAINT [PK_Policy] PRIMARY KEY CLUSTERED ([Id] ASC)
);

