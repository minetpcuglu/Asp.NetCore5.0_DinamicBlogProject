	--Create Trigger AddBlogInRaytingTable
	--on Blogs 
	--After Insert
	--As
	--Declare @ID int 
	--Select @ID=BlogId from inserted
	--insert Into BlogRayting (BlogId , BlogTotelScore ,BlogRaytingCount)
	--values (@ID , 0 ,0 )

	Create Trigger AddScoreInComment
	On Comments
	After insert
	As
	Declare @ID int
	Declare @Score int
	declare @RaytingCount int 
	Select @ID = BlogId,@Score = BlogScore from inserted
	update BlogRayting set BlogTotelScore= BlogTotelScore+@Score,BlogRaytingCount+=1
	where BlogId=@ID
