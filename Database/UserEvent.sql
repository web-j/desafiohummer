CREATE TABLE [dbo].[UserEvent]
(
    [UserId] INT NOT NULL, 
    [EventId] INT NOT NULL,
    [Guest] NVARCHAR(MAX) NULL, 
    [GuestDrink] BIT NULL, 
    [ParticipantDrink] BIT NULL, 
    PRIMARY KEY (UserId, EventId),
    CONSTRAINT [FK_UserEvent_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_UserEvent_Event] FOREIGN KEY ([EventId]) REFERENCES [Event]([Id])
)
