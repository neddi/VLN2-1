CREATE TABLE [dbo].[Users] (
    [UserID]     NVARCHAR (128) NOT NULL,
    [FullName]   NVARCHAR (MAX) NULL,
    [CreateDate] DATETIME       NOT NULL,
    [Info]       NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC),
    CONSTRAINT [FK_Users_AspNetUsers] FOREIGN KEY ([UserID]) REFERENCES [dbo].[AspNetUsers] ([Id])
);


CREATE TABLE [dbo].[UserProjects] (
    [UserID]    NVARCHAR (128) NOT NULL,
    [ProjectId] INT            NOT NULL,
    [IsAdmin]   BIT            NULL,
    PRIMARY KEY CLUSTERED ([ProjectId] ASC, [UserID] ASC),
    CONSTRAINT [FK_UserProjects_Users] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID]),
    CONSTRAINT [FK_UserProjects_Projects] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([ID])
);


CREATE TABLE [dbo].[Projects] (
    [ID]            INT            NOT NULL,
    [Name]          NVARCHAR (MAX) NOT NULL,
    [Description]   NVARCHAR (MAX) NULL,
    [ProjectTypeID] INT            NOT NULL,
    [CreateDate]    DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC), 
    CONSTRAINT [FK_Projects_ProjectTypes] FOREIGN KEY ([ProjectTypeID]) REFERENCES [ProjectTypes]([ID])
);

CREATE TABLE [dbo].[ProjectTypes]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
)

CREATE TABLE [dbo].[Files]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [FileType] NVARCHAR(50) NOT NULL, 
    [Content] NVARCHAR(MAX) NULL
)

CREATE TABLE [dbo].[ProjectFiles] (
    [ProjectID] INT        NOT NULL,
    [FileID]    INT NOT NULL,
    PRIMARY KEY CLUSTERED ([ProjectID] ASC, [FileID] ASC), 
    CONSTRAINT [FK_ProjectFiles_Projects] FOREIGN KEY ([ProjectID]) REFERENCES [Projects]([ID]), 
    CONSTRAINT [FK_ProjectFiles_Files] FOREIGN KEY ([FileID]) REFERENCES [Files]([ID])
);

CREATE VIEW [dbo].[ProjectUsers]
	AS SELECT a.FullName, u.ProjectId, u.IsAdmin FROM AspNetUsers a
	JOIN UserProjects u on a.Id = u.UserID