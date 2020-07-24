CREATE TABLE [dbo].[Buses] (
    [BusId]   INT          IDENTITY (1, 1) NOT NULL,
    [NrReg]   NVARCHAR (9) NOT NULL,
    [NrSeats] INT          NOT NULL,
    CONSTRAINT [PK_dbo.Buses] PRIMARY KEY CLUSTERED ([BusId] ASC)
);

