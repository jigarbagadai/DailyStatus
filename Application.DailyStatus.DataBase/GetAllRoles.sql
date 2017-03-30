CREATE PROCEDURE [dbo].[GetAllRoles]
	@StartRecord AS INT,
	@PageSize AS INT,
	@SortColumn AS NVARCHAR(50),
	@SortOrder AS NVARCHAR(50),
	@SearchText AS NVARCHAR(500),
	@Status AS BIT
AS
	SELECT *
	FROM
	(
		SELECT Id,Name,ModifiedBy,ModifiedDate,IsActive,COUNT(1) OVER() AS TotalRows
		FROM [Role]
		WHERE ISNULL(@SearchText,'ALL')='ALL' OR Name Like '%'+@SearchText+'%' AND IsActive=@Status
	) AS T
	ORDER BY 
		CASE WHEN @SortColumn='RoleName' AND @SortOrder='ASC' THEN Name	END ASC,
		CASE WHEN @SortColumn='ModifiedBy' AND @SortOrder='ASC' THEN ModifiedBy END ASC,
		CASE WHEN @SortColumn='ModifiedDate' AND @SortOrder='ASC' THEN ModifiedDate	END ASC,
		CASE WHEN @SortColumn='IsActive' AND @SortOrder='ASC' THEN IsActive END ASC,
		CASE WHEN @SortColumn='RoleName' AND @SortOrder='DESC' THEN Name END DESC,	
		CASE WHEN @SortColumn='ModifiedBy' AND @SortOrder='DESC' THEN ModifiedBy END DESC,
		CASE WHEN @SortColumn='ModifiedDate' AND @SortOrder='DESC' THEN ModifiedDate END DESC,	 
		CASE WHEN @SortColumn='IsActive' AND @SortOrder='DESC' THEN IsActive END DESC
    OFFSET @StartRecord ROWS FETCH NEXT @PageSize ROWS ONLY;
RETURN 0
