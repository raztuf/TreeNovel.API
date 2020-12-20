﻿CREATE TABLE [dbo].[Article]
(
	[Id] INT NOT NULL IDENTITY (1, 1) PRIMARY KEY,
	[Title] VARCHAR(1000) NOT NULL,
	[Date] DATETIME NOT NULL,
	[Content] VARCHAR(MAX) NOT NULL
)