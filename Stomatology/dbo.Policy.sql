CREATE TABLE [dbo].[Policy] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [PolicyName] NVARCHAR (50) NULL,
    [Allow]      BIT           NULL,
	[IdUser] INT NULL,
    CONSTRAINT [PK_Policy] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Policy_ToUsers] FOREIGN KEY ([IdUser]) REFERENCES [Users]([Id])
);

