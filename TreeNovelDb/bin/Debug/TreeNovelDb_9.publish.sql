﻿/*
Deployment script for TreeNovelDb

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "TreeNovelDb"
:setvar DefaultFilePrefix "TreeNovelDb"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL14.FORMATION\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL14.FORMATION\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
The column [dbo].[Report].[Type] is being dropped, data loss could occur.

The column [dbo].[Report].[Date] on table [dbo].[Report] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column [dbo].[Report].[Subject] on table [dbo].[Report] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.
*/

IF EXISTS (select top 1 1 from [dbo].[Report])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Starting rebuilding table [dbo].[Report]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Report] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Title]   VARCHAR (1000) NOT NULL,
    [Content] VARCHAR (MAX)  NOT NULL,
    [Date]    DATETIME       NOT NULL,
    [Subject] VARCHAR (1000) NOT NULL,
    [UserId]  INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Report])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Report] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Report] ([Id], [Title], [Content], [UserId])
        SELECT   [Id],
                 [Title],
                 [Content],
                 [UserId]
        FROM     [dbo].[Report]
        ORDER BY [Id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Report] OFF;
    END

DROP TABLE [dbo].[Report];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Report]', N'Report';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Update complete.';


GO
