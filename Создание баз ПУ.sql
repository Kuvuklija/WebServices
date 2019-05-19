--CREATE TABLE [dbo].[Arrivals] (
--    [Id]            BIGINT         IDENTITY (1, 1) NOT NULL,
--    [Location] NVARCHAR (MAX) NULL,
--    [Document] NVARCHAR (MAX) NULL,
--	[Status] NVARCHAR (MAX) NULL,
--    CONSTRAINT [PK_dbo.Arrivals] PRIMARY KEY CLUSTERED ([Id] ASC),
--);

--CREATE TABLE [dbo].[Materials] (
--    [Id]            BIGINT         IDENTITY (1, 1) NOT NULL,
--    [Artikul] NVARCHAR (MAX) NULL,
--    [Batch] NVARCHAR (MAX) NULL,
--	[RegForm1] NVARCHAR (MAX) NULL,
--	[RegForm2] NVARCHAR (MAX) NULL,
--	[AlcoCode] NVARCHAR (MAX) NULL,
--	[DocumentRow] NVARCHAR (MAX) NULL,
--    [ArrivalId] BIGINT         NOT NULL,
--    CONSTRAINT [PK_dbo.Materials] PRIMARY KEY CLUSTERED ([Id] ASC),
--    CONSTRAINT [FK_dbo.Materials_dbo.Arrivals_ArrivalId] FOREIGN KEY ([ArrivalId]) REFERENCES [dbo].[Arrivals] ([Id]) ON DELETE CASCADE,
--);


--GO
--CREATE NONCLUSTERED INDEX [IX_HeadReserveId]
--    ON [dbo].[Materials]([ArrivalId] ASC);

--CREATE TABLE [dbo].[Pallets] (
--    [Id]            BIGINT         IDENTITY (1, 1) NOT NULL,
--    [VirtualPallete] BIT,
--    [PalletCode] NVARCHAR (MAX) NULL,
--    [MaterialId] BIGINT         NOT NULL,
--    CONSTRAINT [PK_dbo.Pallets] PRIMARY KEY CLUSTERED ([Id] ASC),
--    CONSTRAINT [FK_dbo.Pallets_dbo.Materials_MaterialId] FOREIGN KEY ([MaterialId]) REFERENCES [dbo].[Materials] ([Id]) ON DELETE CASCADE,
--);


--GO
--CREATE NONCLUSTERED INDEX [IX_HeadReserveId]
--    ON [dbo].[Pallets]([MaterialId] ASC);


--CREATE TABLE [dbo].[Cartons] (
--    [Id]            BIGINT         IDENTITY (1, 1) NOT NULL,
--    [VirtualCarton] BIT,
--    [CartonCode] NVARCHAR (MAX) NULL,
--    [PalletId] BIGINT         NOT NULL,
--    CONSTRAINT [PK_dbo.Cartons] PRIMARY KEY CLUSTERED ([Id] ASC),
--    CONSTRAINT [FK_dbo.Cartons_dbo.Pallets_PalletId] FOREIGN KEY ([PalletId]) REFERENCES [dbo].[Pallets] ([Id]) ON DELETE CASCADE,
--);


--GO
--CREATE NONCLUSTERED INDEX [IX_HeadReserveId]
--    ON [dbo].[Cartons]([PalletId] ASC);
DROP TABLE Marks;

CREATE TABLE [dbo].[Marks] (
    [Id]            BIGINT         IDENTITY (1, 1) NOT NULL,
    [MarkCode] NVARCHAR (150) NOT NULL,
    [CartonId] BIGINT         NOT NULL,
    CONSTRAINT [PK_dbo.Marks] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Marks_dbo.Cartons_CartonId] FOREIGN KEY ([CartonId]) REFERENCES [dbo].[Cartons] ([Id]) ON DELETE CASCADE,
);


GO
CREATE NONCLUSTERED INDEX [IX_HeadReserveId]
    ON [dbo].[Marks]([CartonId] ASC);