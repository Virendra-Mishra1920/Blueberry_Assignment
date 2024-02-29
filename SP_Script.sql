Create procedure [dbo].[AddNewUser]  
(  
   @Name varchar (50),  
   @Email varchar (50),  
   @Address varchar (50)  
)  
as  
begin  
   Insert into Users values(@Name,@Email,@Address)  
End 

go 
Create Procedure [dbo].[GetAllUsers]  
as  
begin  
   select *from Users  
End 


go


Create procedure [dbo].[UpdateUserDetails]  
(  
   @UserId int,  
   @Name varchar (50),  
   @Email varchar (50),  
   @Address varchar (50)  
)  
as  
begin  
   Update Users   
   set Name=@Name,  
   Email=@Email,  
   Address=@Address  
   where Id=@UserId
End 


go
Create procedure [dbo].[DeleteUserById]  
(  
   @UserId int  
)  
as   
begin  
   Delete from Users where Id=@UserId 
End 


--- table create script

CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Address] [nchar](10) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO