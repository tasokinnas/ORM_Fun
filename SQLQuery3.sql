-- Explain cte vs temp table.  look at views (for personall knowledge).

WITH [GFEData] AS (
SELECT [Cohort].[Name] AS [Cohort]
	,[Cohort].[Id] AS [CohortId]
	,[GfGroup].[Name] AS [Group]
	,[Dimension].[Name] AS [Dimension]
	,[Facet].[Name] AS [Facet]
	,[Expectation].[Description] AS [Expectation]
FROM [CohortFacetExpectation]
	INNER JOIN [Cohort] ON [CohortFacetExpectation].[CohortId] = [Cohort].[ID]
	INNER JOIN [Facet] ON [CohortFacetExpectation].[FacetId] = [Facet].[Id]
	INNER JOIN [Expectation] ON  [CohortFacetExpectation].[ExpectationId] = [Expectation].[Id]
	INNER JOIN [Dimension] ON [Facet].[DimensionId] = [Dimension].[Id]
	INNER JOIN [GfGroup] ON [Dimension].[GfGroupId] = [GfGroup].[Id]
),

[NextCohort] AS (
SELECT [N].[Name] AS [NextCohort]
	,[C].[Id] AS [CohortId]
FROM [Cohort] AS [C]
	INNER JOIN [Cohort] AS [N] ON [C].[NextCohortId] = [N].[Id]
)

SELECT [GFEData].[Cohort]
	,[NextCohort].[NextCohort]
	,[GFEData].[Group]
	,[GFEData].[Dimension]
	,[GFEData].[Facet]
	,[GFEData].[Expectation]
FROM [GFEData]
	INNER JOIN [NextCohort] ON [GFEData].[CohortId] = [NextCohort].[CohortId]
WHERE [GFEData].[Cohort] = 'Consultant'





SELECT *
FROM [AllataGFE].[dbo].[Cohort]

SELECT *
FROM [AllataGFE].[dbo].[GfGroup]
	INNER JOIN [Dimension] ON [GfGroup].[Id] = [Dimension].[GfGroupId]
WHERE [GfGroup].[Id] = 'BED896FD-4C23-48B6-8C70-CE49F92C0D75' 

SELECT *
FROM [AllataGFE].[dbo].[Dimension]

SELECT *
FROM [AllataGFE].[dbo].[Facet]

SELECT *
FROM [AllataGFE].[dbo].[Expectation]

SELECT *
FROM [AllataGFE].[dbo].[CohortFacetExpectation]