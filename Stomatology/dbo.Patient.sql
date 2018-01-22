CREATE TABLE [dbo].[Patient]
(
	[PatientId]                 INT            IDENTITY (1, 1) NOT NULL,
	[Name]                       NVARCHAR (50)  NULL,
    [State]                      BIT     NULL,
    [Birthday]                   NCHAR (12)     NULL,
    [Number]                     NVARCHAR (50)  NULL,
    [Adress]                     NVARCHAR (50)  NULL
)
