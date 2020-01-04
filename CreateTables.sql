-- Clear in reverse order due to foreign key constraints
IF OBJECT_ID('dbo.Expectation_Facet_Cohort', 'U') IS NOT NULL DROP TABLE dbo.Expectation_Facet_Cohort;
IF OBJECT_ID('dbo.Expectation', 'U') IS NOT NULL DROP TABLE dbo.Expectation;
IF OBJECT_ID('dbo.Facet', 'U') IS NOT NULL DROP TABLE dbo.Facet; 
IF OBJECT_ID('dbo.Dimension', 'U') IS NOT NULL DROP TABLE dbo.Dimension; 
IF OBJECT_ID('dbo.GF_Group', 'U') IS NOT NULL DROP TABLE dbo.GF_Group; 
IF OBJECT_ID('dbo.Cohort', 'U') IS NOT NULL DROP TABLE dbo.Cohort;

-- Create Cohort Tables
-- TODO: Add fk cohort ID for subsequent cohort level (promotion)
CREATE TABLE dbo.Cohort  (
	[Id] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID() NOT NULL,   
	[Name] VARCHAR(50) NOT NULL,
	[Next_Cohort_Id] UNIQUEIDENTIFIER NULL,
	CONSTRAINT fk_Cohort_Cohort FOREIGN KEY ([Next_Cohort_Id]) REFERENCES Cohort ([Id]),
);

-- Create Group-Dimension-Facet Tables
CREATE TABLE dbo.GF_Group  (
	[Id] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID() NOT NULL,   
	[Name] VARCHAR(50) NOT NULL
);

CREATE TABLE dbo.Dimension  (
	[Id] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID() NOT NULL,   
	[Name] VARCHAR(50) NOT NULL,
	[GF_Group_Id] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT fk_Expectation_GF_Group FOREIGN KEY ([GF_Group_Id]) REFERENCES GF_Group ([Id])
);

CREATE TABLE dbo.Facet  (
	[Id] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID() NOT NULL,   
	[Name] VARCHAR(50) NOT NULL,
	[Dimension_Id] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT fk_Expectation_Dimension FOREIGN KEY ([Dimension_Id]) REFERENCES Dimension ([Id])
);

-- Create Expectation Table
CREATE TABLE dbo.Expectation  (
	[Facet_Id] UNIQUEIDENTIFIER NOT NULL,
	[Cohort_Id] UNIQUEIDENTIFIER NOT NULL, 
	[Description] VARCHAR(500) NOT NULL,
	CONSTRAINT fk_Expectation_Facet FOREIGN KEY ([Facet_Id]) REFERENCES Facet ([Id]),
	CONSTRAINT fk_Expectation_Cohort FOREIGN KEY ([Cohort_Id]) REFERENCES Cohort ([Id])
);




-- Create Expectation-Facet-Cohort Table
CREATE TABLE dbo.Expectation_Facet_Cohort (
	[Expectation_Id] UNIQUEIDENTIFIER NOT NULL,
	[Facet_Id] UNIQUEIDENTIFIER NOT NULL,
	[Cohort_Id] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT fk_Expectation_Facet_Cohort_Expectation FOREIGN KEY ([Expectation_Id]) REFERENCES Expectation ([Id]),
	CONSTRAINT fk_Expectation_Facet_Cohort_Facet FOREIGN KEY ([Facet_Id]) REFERENCES Facet ([Id]),
	CONSTRAINT fk_Expectation_Facet_Cohort_Cohort FOREIGN KEY ([Cohort_Id]) REFERENCES Cohort ([Id])
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