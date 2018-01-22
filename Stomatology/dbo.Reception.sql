﻿CREATE TABLE [dbo].[Reception] (
    [Id] INT            IDENTITY (1, 1) NOT NULL,
    [Date]         date NOT NULL DEFAULT SYSDATETIME(),
    [Doctor]       NVARCHAR (50)  NULL,
    [Info]         NVARCHAR (MAX) NULL,
    [Money]        FLOAT (53)     NULL,
    [Arrears]      INT            NULL,
    [tlt1]         NVARCHAR (MAX) NULL,
    [tlt2]         NVARCHAR (MAX) NULL,
    [tlt3]         NVARCHAR (MAX) NULL,
    [tlt4]         NVARCHAR (MAX) NULL,
    [tlt5]         NVARCHAR (MAX) NULL,
    [tlt6]         NVARCHAR (MAX) NULL,
    [tlt7]         NVARCHAR (MAX) NULL,
    [tlt8]         NVARCHAR (MAX) NULL,
    [trt1]         NVARCHAR (MAX) NULL,
    [trt2]         NVARCHAR (MAX) NULL,
    [trt3]         NVARCHAR (MAX) NULL,
    [trt4]         NVARCHAR (MAX) NULL,
    [trt5]         NVARCHAR (MAX) NULL,
    [trt6]         NVARCHAR (MAX) NULL,
    [trt7]         NVARCHAR (MAX) NULL,
    [trt8]         NVARCHAR (MAX) NULL,
    [brt1]         NVARCHAR (MAX) NULL,
    [brt2]         NVARCHAR (MAX) NULL,
    [brt3]         NVARCHAR (MAX) NULL,
    [brt4]         NVARCHAR (MAX) NULL,
    [brt5]         NVARCHAR (MAX) NULL,
    [brt6]         NVARCHAR (MAX) NULL,
    [brt7]         NVARCHAR (MAX) NULL,
    [brt8]         NVARCHAR (MAX) NULL,
    [blt1]         NVARCHAR (MAX) NULL,
    [blt2]         NVARCHAR (MAX) NULL,
    [blt3]         NVARCHAR (MAX) NULL,
    [blt4]         NVARCHAR (MAX) NULL,
    [blt5]         NVARCHAR (MAX) NULL,
    [blt6]         NVARCHAR (MAX) NULL,
    [blt7]         NVARCHAR (MAX) NULL,
    [blt8]         NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	);
