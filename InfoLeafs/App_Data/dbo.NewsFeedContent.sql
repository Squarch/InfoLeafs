CREATE TABLE [dbo].[NewsFeedContent] (
    [Id]      INT           IDENTITY (1, 1) NOT NULL,
    [Title]   NVARCHAR (50) NOT NULL,
    [Content] NVARCHAR (50) NOT NULL,
    [DataTimePublication] DATETIME NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

