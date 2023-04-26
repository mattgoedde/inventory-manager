SELECT TOP (1000) [Id]
      ,[Name]
  FROM [Inventory].[dbo].[Tenants]
;

SELECT TOP (1000) [Id]
      ,[Name]
      ,[LocationTypeId]
      ,[ParentLocationId]
      ,[TenantId]
  FROM [Inventory].[dbo].[Locations]

;

SELECT TOP (1000) [Id]
      ,[Name]
      ,[TenantId]
  FROM [Inventory].[dbo].[LocationTypes]

;

WITH TenantLocationTree ([TenantId], [ParentLocationId], [LocationTypeId], [Id], [Name], [Level])
AS
(
    SELECT TenantId, ParentLocationId, LocationTypeId, Id, [Name], 0 AS [Level]
    FROM Locations l1
    WHERE ParentLocationId IS NULL
    UNION ALL
    SELECT l2.TenantId, l2.ParentLocationId, l2.LocationTypeId, l2.Id, l2.Name, [Level] + 1 AS [Level]
    FROM Locations l2
    INNER JOIN TenantLocationTree l3 ON l2.ParentLocationId = l3.Id
)
SELECT * FROM TenantLocationTree WHERE TenantId = '6b19db00-dca9-4f50-b237-afe0f9d04ae9'
ORDER BY Level, Level, TenantId, LocationTypeId