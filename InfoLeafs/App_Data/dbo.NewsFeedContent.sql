CREATE TABLE [dbo].[NewsFeedContent] (
    [Id] INT           NOT NULL IDENTITY,
    [Title]      NVARCHAR (50) NOT NULL,
    [Content]    NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

