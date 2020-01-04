WITH [GFEData] AS (
SELECT [Cohort].[Name] AS [Cohort]
	,[Cohort].[Id] AS [Cohort Id]
	,[GF_Group].[Name] AS [Group]
	,[Dimension].[Name] AS [Dimension]
	,[Facet].[Name] AS [Facet]
	,[Expectation].[Description] AS [Expectation]
FROM [Expectation]
	INNER JOIN [Facet] ON [Expectation].[Facet_Id] = [Facet].[Id]
	INNER JOIN [Cohort] ON [Expectation].[Cohort_Id] = [Cohort].[ID]
	INNER JOIN [Dimension] ON [Facet].[Dimension_Id] = [Dimension].[Id]
	INNER JOIN [GF_Group] ON [Dimension].[GF_Group_Id] = [GF_Group].[Id]
),

[NextCohort] AS (
SELECT [N].[Name] AS [Next_Cohort]
	,[C].[Id] AS [Cohort Id]
FROM [Cohort] AS [C]
	INNER JOIN [Cohort] AS [N] ON [C].[Next_Cohort_Id] = [N].[Id]
)

SELECT [GFEData].[Cohort]
	,[NextCohort].[Next_Cohort]
	,[GFEData].[Group]
	,[GFEData].[Dimension]
	,[GFEData].[Facet]
	,[GFEData].[Expectation]
FROM [GFEData]
	INNER JOIN [NextCohort] ON [GFEData].[Cohort Id] = [NextCohort].[Cohort Id]