CREATE TABLE [dbo].[Reservations] (
    [ReservationId]   INT            IDENTITY (1, 1) NOT NULL,
    [ReservationDate] DATETIME       NOT NULL,
    [TourId]          INT            NOT NULL,
    [UserName]        NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Reservations] PRIMARY KEY CLUSTERED ([ReservationId] ASC),
    CONSTRAINT [FK_dbo.Reservations_dbo.Tours_TourId] FOREIGN KEY ([TourId]) REFERENCES [dbo].[Tours] ([TourId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_TourId]
    ON [dbo].[Reservations]([TourId] ASC);

