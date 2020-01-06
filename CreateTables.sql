-- Clear in reverse order due to foreign key constraints
IF OBJECT_ID('dbo.Expectation', 'U') IS NOT NULL DROP TABLE dbo.Expectation;
IF OBJECT_ID('dbo.Facet', 'U') IS NOT NULL DROP TABLE dbo.Facet; 
IF OBJECT_ID('dbo.Dimension', 'U') IS NOT NULL DROP TABLE dbo.Dimension; 
IF OBJECT_ID('dbo.GfGroup', 'U') IS NOT NULL DROP TABLE dbo.GfGroup; 
IF OBJECT_ID('dbo.Cohort', 'U') IS NOT NULL DROP TABLE dbo.Cohort;

-- Create Cohort Tables
-- TODO: Add fk cohort ID for subsequent cohort level (promotion)
CREATE TABLE dbo.Cohort  (
	[Id] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID() NOT NULL,   
	[Name] VARCHAR(50) NOT NULL,
	[Rank] INT NOT NULL,
	[NextCohortId] UNIQUEIDENTIFIER NULL,
	CONSTRAINT fk_Cohort_Cohort FOREIGN KEY ([NextCohortId]) REFERENCES Cohort ([Id]),
);

-- Create Group-Dimension-Facet Tables
CREATE TABLE dbo.GfGroup  (
	[Id] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID() NOT NULL,   
	[Name] VARCHAR(50) NOT NULL
);

CREATE TABLE dbo.Dimension  (
	[Id] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID() NOT NULL,   
	[Name] VARCHAR(50) NOT NULL,
	[GfGroupId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT fk_Expectation_GF_Group FOREIGN KEY ([GfGroupId]) REFERENCES GfGroup ([Id])
);

CREATE TABLE dbo.Facet  (
	[Id] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID() NOT NULL,   
	[Name] VARCHAR(50) NOT NULL,
	[DimensionId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT fk_Expectation_Dimension FOREIGN KEY ([DimensionId]) REFERENCES Dimension ([Id])
);

-- Create Expectation Table
CREATE TABLE dbo.Expectation  (
	[FacetId] UNIQUEIDENTIFIER NOT NULL,
	[CohortId] UNIQUEIDENTIFIER NOT NULL, 
	[Description] VARCHAR(500) NOT NULL,
	CONSTRAINT fk_Expectation_Facet FOREIGN KEY ([FacetId]) REFERENCES Facet ([Id]),
	CONSTRAINT fk_Expectation_Cohort FOREIGN KEY ([CohortId]) REFERENCES Cohort ([Id])
);






-- For CodeMaze Tutorial...
IF OBJECT_ID('dbo.Account', 'U') IS NOT NULL DROP TABLE dbo.Account; 
IF OBJECT_ID('dbo.Owner', 'U') IS NOT NULL DROP TABLE dbo.Owner; 

CREATE TABLE dbo.Owner  (
	OwnerID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),  
	Name VARCHAR(60) NOT NULL,
	DateOfBirth DATE NOT NULL,
	Address VARCHAR(100)
);

CREATE TABLE dbo.Account  (
	AccountID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),  
	DateCreated DATE NOT NULL,
	AccountType VARCHAR(45),
	OwnerID UNIQUEIDENTIFIER NOT NULL, 
	CONSTRAINT fk_Account_Owner FOREIGN KEY (OwnerID) references Owner (OwnerID)
);