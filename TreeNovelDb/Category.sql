﻿CREATE TABLE [dbo].[Category]
(
	[Id] INT NOT NULL IDENTITY (1, 1) PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL UNIQUE,
	[Sidebar] VARCHAR(MAX)
)
