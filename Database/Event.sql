﻿CREATE TABLE [dbo].[Event]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Created] DATETIMEOFFSET NULL, 
    [LastUpdate] DATETIMEOFFSET NULL, 
    [Erased] INT NULL,
    [EventName] NVARCHAR(50) NULL, 
    [EventDate] DATETIMEOFFSET NULL, 
    [StatusEvent] INT NULL
)
