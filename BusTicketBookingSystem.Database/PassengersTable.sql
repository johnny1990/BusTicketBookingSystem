CREATE TABLE [dbo].[Passengers] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (128) NOT NULL,
    [Blocked] BIT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_dbo.Passengers] PRIMARY KEY CLUSTERED ([Id] ASC)
);

