CREATE TABLE [dbo].[Subscription]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [IdUser] INT NOT NULL, 
    [IdSubscriber] INT NOT NULL, 
    CONSTRAINT [FK_Subscription_ToTable] FOREIGN KEY ([IdUser]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_Subscription_ToTable_1] FOREIGN KEY ([IdSubscriber]) REFERENCES [Users]([Id])
)
