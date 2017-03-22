CREATE PROCEDURE [dbo].[GetAllRoles]
	@StartRecord AS INT,
	@PageSize AS INT,
	@SortColumn AS NVARCHAR(50),
	@SortOrder AS NVARCHAR(50),
	@SearchText AS NVARCHAR(500)
AS
	SELECT *
	FROM
	(
		SELECT Id,Name,ModifiedBy,ModifiedDate,IsActive,COUNT(1) OVER() AS TotalRows
		FROM [Role]
		WHERE ISNULL(@SearchText,'')='' OR Name Like '%'+@SearchText+'%'
	) AS T
	ORDER BY 
	CASE WHEN @SortColumn='NAME' AND @SortOrder='ASC' THEN Name	
		 WHEN @SortColumn='ModifiedBy' AND @SortOrder='ASC' THEN ModifiedBy
		 WHEN @SortColumn='ModifiedDate' AND @SortOrder='ASC' THEN ModifiedDate	
		 WHEN @SortColumn='IsActive' AND @SortOrder='ASC' THEN IsActive
		 ELSE NULL
	END ASC,
	CASE WHEN @SortColumn='NAME' AND @SortOrder='DESC' THEN Name	
		 WHEN @SortColumn='ModifiedBy' AND @SortOrder='DESC' THEN ModifiedBy
		 WHEN @SortColumn='ModifiedDate' AND @SortOrder='DESC' THEN ModifiedDate	
		 WHEN @SortColumn='IsActive' AND @SortOrder='DESC' THEN IsActive
		 ELSE NULL
	END DESC
    OFFSET @StartRecord ROWS FETCH NEXT @PageSize ROWS ONLY;
RETURN 0
