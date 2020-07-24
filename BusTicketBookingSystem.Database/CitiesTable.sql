CREATE TABLE [dbo].[Cities] (
    [CityId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Cities] PRIMARY KEY CLUSTERED ([CityId] ASC)
);