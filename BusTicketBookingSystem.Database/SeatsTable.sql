CREATE TABLE [dbo].[Seats] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [IsAvailable] BIT            NOT NULL,
    [SeatNumber]  INT            NOT NULL,
    [PassengerId] INT            NOT NULL,
    [BusId]       INT            NULL,
    [Time]        NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    CONSTRAINT [PK_dbo.Seats] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Seats_dbo.Passengers_Passenger_Id] FOREIGN KEY ([PassengerId]) REFERENCES [dbo].[Passengers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Seats_dbo.Buses_Bus_Id] FOREIGN KEY ([BusId]) REFERENCES [dbo].[Buses] ([BusId])
);


GO
CREATE NONCLUSTERED INDEX [IX_PassengerId]
    ON [dbo].[Seats]([PassengerId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Bus_Id]
    ON [dbo].[Seats]([BusId] ASC);

