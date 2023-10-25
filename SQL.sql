SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[users](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY,
	[Username] [varchar](200) NOT NULL,
	[Password] [varchar](500) NULL,
	[Email] [char](3) NOT NULL,
	[Name] [int] NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tasks](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY,
	[Title] [varchar](500) NOT NULL,
	[IsDone] [varchar](1) NULL,
	[UserId] [int] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tasks]
ADD CONSTRAINT FK_Tasks_Users
FOREIGN KEY (UserId)
REFERENCES [dbo].[users] (Id);
GO