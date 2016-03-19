CREATE TABLE [dbo].[NewsFeed] (
    [Id] INT NOT NULL IDENTITY, 
	[UserId]     INT NOT NULL,
    [NewsFeedId] INT NOT NULL, 
    CONSTRAINT [NewsFeedId] FOREIGN KEY ([NewsFeedId]) REFERENCES [NewsFeedContent]([Id]), 
    CONSTRAINT [UserId] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]), 
    CONSTRAINT [PK_NewsFeed] PRIMARY KEY ([Id]),
);

