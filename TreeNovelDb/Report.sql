﻿CREATE TABLE [dbo].[Report]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[Title] VARCHAR(1000) NOT NULL,
	[Content] VARCHAR(MAX) NOT NULL,
	[Date] DATETIME NOT NULL,
	[Subject] VARCHAR(1000) NOT NULL,
	[UserId] INT NOT NULL
)
