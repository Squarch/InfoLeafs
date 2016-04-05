CREATE TABLE [dbo].[User] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Login]    NVARCHAR (50) NOT NULL,
    [Password] NVARCHAR (50) NOT NULL,
    [AvatarPath]   NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

