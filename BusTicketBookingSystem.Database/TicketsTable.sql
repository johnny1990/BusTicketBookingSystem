CREATE TABLE [dbo].[Tickets] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [BookingTime]  NVARCHAR (MAX)  NOT NULL,
    [IsBlocked]    BIT             NOT NULL,
    [Trip_Id]      INT             NOT NULL,
    [Passenger_Id] INT             NULL,
    [Price]        DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_dbo.Tickets] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Tickets_dbo.Tours_Tour_Id] FOREIGN KEY ([Trip_Id]) REFERENCES [dbo].[Tours] ([TourId]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Tickets_dbo.Passengers_Passenger_Id] FOREIGN KEY ([Passenger_Id]) REFERENCES [dbo].[Passengers] ([Id])
);

