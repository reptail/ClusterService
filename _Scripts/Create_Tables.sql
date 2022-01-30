USE ClusterService;

DROP TABLE IF EXISTS dbo.Leases;

CREATE TABLE dbo.Leases (
	[Id]				BIGINT				IDENTITY(1,1),
	[System]			NVARCHAR(300)		NOT NULL,
	[AquiredAtUtc]		DATETIME2(3)		NOT NULL,
	[AquiredBy]			NVARCHAR(300)		NOT NULL,
	[ExpiresAtUtc]		DATETIME2(3)		NOT NULL,
	[ReleasedAtUtc]		DATETIME2(3)		NULL,
	[GracePeriod]		TIME				NOT NULL,
	[Token]				UNIQUEIDENTIFIER	NOT NULL	    DEFAULT(NEWID()),
	[IsLatest]			BIT					NOT NULL,
	CONSTRAINT PK_Leases_Id 
		PRIMARY KEY CLUSTERED ( [Id] )
);

CREATE UNIQUE NONCLUSTERED INDEX UX_Leases_SystemIsLatest 
	ON dbo.Leases (
		[System]
	)
	INCLUDE (
		[Id],
		[AquiredAtUtc],
		[AquiredBy],
		[ExpiresAtUtc],
		[GracePeriod],
		[Token],
		[IsLatest]
	)
	WHERE (
		[IsLatest] = 1
	);

CREATE NONCLUSTERED INDEX IX_Leases_SystemToken
	ON dbo.Leases (
		[System],
		[Token]
	)
	INCLUDE (
		[Id],
		[AquiredAtUtc],
		[AquiredBy],
		[ExpiresAtUtc],
		[GracePeriod],
		[IsLatest]
	);

