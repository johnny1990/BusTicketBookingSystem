CREATE TABLE [dbo].[Feedbacks] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [FromPassenger] NVARCHAR (50)  NULL,
    [FromEmail]     NVARCHAR (50)  NULL,
    [Feedback]      NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED ([Id] ASC)
);

