CREATE TABLE [dbo].[Users] (
    [Id]   INT           NOT NULL IDENTITY,
    [Login]    NVARCHAR (50) NOT NULL,
    [Password] NVARCHAR (50) NOT NULL,
    [Access]   NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

