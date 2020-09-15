CREATE TABLE [dbo].[Drivers] (
    [DriverId]      INT            IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (250) NOT NULL,
    [SerialNumber]  NVARCHAR (250) NOT NULL,
    [DriverLicence] NVARCHAR (250) NOT NULL,
    [PhoneNumber]   NVARCHAR (250) NOT NULL,
    [EmailAddress]  NVARCHAR (250) NOT NULL,
    [IsAvailable]   BIT            NOT NULL,
    CONSTRAINT [PK_dbo.Drivers] PRIMARY KEY CLUSTERED ([DriverId] ASC)
);

