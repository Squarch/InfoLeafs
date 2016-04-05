CREATE TABLE [dbo].[Subscription] (
    [Id]           INT NOT NULL IDENTITY,
    [IdUser]       INT NOT NULL,
    [IdSubscriber] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Subscription_ToTable] FOREIGN KEY ([IdUser]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_Subscription_ToTable_1] FOREIGN KEY ([IdSubscriber]) REFERENCES [dbo].[User] ([Id])
);

