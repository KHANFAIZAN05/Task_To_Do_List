USE [DbTasks]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 24-04-2021 14:18:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[TaskId] [int] IDENTITY(1,1) NOT NULL,
	[TaskName] [nvarchar](max) NULL,
	[TskStatus] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Insert]    Script Date: 24-04-2021 14:18:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_Insert]
(
@TaskName nvarchar(max),
@TaskStatus nvarchar(max)
)
As
begin
insert into Task values(@TaskName,@TaskStatus)


select * from Task Where TaskId = SCOPE_IDENTITY()
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_UpdateTask]    Script Date: 24-04-2021 14:18:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_UpdateTask]
(
@TaskId int,
@TaskName nvarchar(max),
@TaskStatus nvarchar(max)
)

as
begin
 update task Set 
[TaskName]=@TaskName,
[TskStatus]=@TaskStatus

where TasKid =@TaskId

select * from Task Where TaskId = SCOPE_IDENTITY()

end
GO
