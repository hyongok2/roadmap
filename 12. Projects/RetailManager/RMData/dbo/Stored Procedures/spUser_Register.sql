CREATE PROCEDURE [dbo].[spUser_Register]
	@Id nvarchar(128),
	@FirstName NCHAR(50),
	@LastName NCHAR(50),
	@EmailAddress NVARCHAR(256),
	@CreatedDate DATETIME2
AS

begin
	set nocount on;

	insert into [dbo].[User](Id,FirstName,LastName,EmailAddress,CreatedDate)
	values(@Id,@FirstName,@LastName,@EmailAddress,@CreatedDate);

end