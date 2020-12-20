﻿CREATE TABLE [dbo].[Chapter]
(
	[Id] INT NOT NULL IDENTITY (1, 1) PRIMARY KEY,
	[Title] VARCHAR(100) NOT NULL UNIQUE,
	[Date] DATETIME NOT NULL,
	[Content] VARCHAR(MAX) NOT NULL,
	[UserId] INT FOREIGN KEY REFERENCES [User](Id),
	[LastChapterId] INT FOREIGN KEY REFERENCES [Chapter](Id),
	[Encyclopedia] VARCHAR(MAX),
	[CategoryName] VARCHAR(100) FOREIGN KEY REFERENCES [Category](Name)
)