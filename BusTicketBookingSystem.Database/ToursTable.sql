CREATE TABLE [dbo].[Tours] (
    [TourId]         INT             IDENTITY (1, 1) NOT NULL,
    [TourDate]       DATETIME        NOT NULL,
    [CityId]         INT             NOT NULL,
    [Departure]      NVARCHAR (MAX)  NOT NULL,
    [Arrival]        NVARCHAR (MAX)  NOT NULL,
    [BusId]          INT             NOT NULL,
    [SeatsAvailable] INT             NOT NULL,
    [Price]          DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_dbo.Tours] PRIMARY KEY CLUSTERED ([TourId] ASC),
    CONSTRAINT [FK_dbo.Tours_dbo.Buses_BusId] FOREIGN KEY ([BusId]) REFERENCES [dbo].[Buses] ([BusId]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Tours_dbo.Cities_CityId] FOREIGN KEY ([CityId]) REFERENCES [dbo].[Cities] ([CityId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_BusId]
    ON [dbo].[Tours]([BusId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CityId]
    ON [dbo].[Tours]([CityId] ASC);

