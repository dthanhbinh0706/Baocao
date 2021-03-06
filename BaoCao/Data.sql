USE [master]
GO
/****** Object:  Database [Data]    Script Date: 12/19/2020 8:54:28 PM ******/
CREATE DATABASE [Data]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.DTHANHBINH\MSSQL\DATA\Data.mdf' , SIZE = 7168KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Data_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.DTHANHBINH\MSSQL\DATA\Data_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Data] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Data].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Data] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Data] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Data] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Data] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Data] SET ARITHABORT OFF 
GO
ALTER DATABASE [Data] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Data] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Data] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Data] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Data] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Data] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Data] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Data] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Data] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Data] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Data] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Data] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Data] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Data] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Data] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Data] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Data] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Data] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Data] SET  MULTI_USER 
GO
ALTER DATABASE [Data] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Data] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Data] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Data] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Data] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Data]
GO
/****** Object:  Table [dbo].[AssigneeDepartments]    Script Date: 12/19/2020 8:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssigneeDepartments](
	[AssigneeDepartmentId] [int] NOT NULL,
	[AssigneeId] [int] NULL,
	[DepartmentId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[AssigneeDepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Assignees]    Script Date: 12/19/2020 8:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assignees](
	[AssigneeId] [int] NOT NULL,
	[AssigneeName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Assignees] PRIMARY KEY CLUSTERED 
(
	[AssigneeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AssigneeTasks]    Script Date: 12/19/2020 8:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssigneeTasks](
	[AssigneeTaskId] [int] NOT NULL,
	[AssigneeId] [int] NOT NULL,
	[TaskId] [int] NOT NULL,
	[StateId] [int] NOT NULL,
	[Schedule] [datetime] NULL,
 CONSTRAINT [AT_st] PRIMARY KEY CLUSTERED 
(
	[AssigneeTaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departments]    Script Date: 12/19/2020 8:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentId] [int] NOT NULL,
	[DepartmentName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reports]    Script Date: 12/19/2020 8:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reports](
	[StateId] [int] NOT NULL,
	[Total] [int] NULL,
 CONSTRAINT [PK_Reports_1] PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[States]    Script Date: 12/19/2020 8:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[States](
	[StateId] [int] NOT NULL,
	[StateName] [nvarchar](50) NULL,
 CONSTRAINT [AS_st] PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 12/19/2020 8:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[TaskId] [int] NOT NULL,
	[TaskName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[AssigneeDepartments]  WITH CHECK ADD  CONSTRAINT [FK_AssigneeDepartments_Assignees] FOREIGN KEY([AssigneeId])
REFERENCES [dbo].[Assignees] ([AssigneeId])
GO
ALTER TABLE [dbo].[AssigneeDepartments] CHECK CONSTRAINT [FK_AssigneeDepartments_Assignees]
GO
ALTER TABLE [dbo].[AssigneeDepartments]  WITH CHECK ADD  CONSTRAINT [FK_AssigneeDepartments_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([DepartmentId])
GO
ALTER TABLE [dbo].[AssigneeDepartments] CHECK CONSTRAINT [FK_AssigneeDepartments_Departments]
GO
ALTER TABLE [dbo].[AssigneeTasks]  WITH CHECK ADD  CONSTRAINT [AT_A] FOREIGN KEY([AssigneeId])
REFERENCES [dbo].[Assignees] ([AssigneeId])
GO
ALTER TABLE [dbo].[AssigneeTasks] CHECK CONSTRAINT [AT_A]
GO
ALTER TABLE [dbo].[AssigneeTasks]  WITH CHECK ADD  CONSTRAINT [AT_T] FOREIGN KEY([TaskId])
REFERENCES [dbo].[Tasks] ([TaskId])
GO
ALTER TABLE [dbo].[AssigneeTasks] CHECK CONSTRAINT [AT_T]
GO
ALTER TABLE [dbo].[AssigneeTasks]  WITH CHECK ADD  CONSTRAINT [FK_ATS] FOREIGN KEY([StateId])
REFERENCES [dbo].[States] ([StateId])
GO
ALTER TABLE [dbo].[AssigneeTasks] CHECK CONSTRAINT [FK_ATS]
GO
ALTER TABLE [dbo].[Reports]  WITH CHECK ADD  CONSTRAINT [R_S] FOREIGN KEY([StateId])
REFERENCES [dbo].[States] ([StateId])
GO
ALTER TABLE [dbo].[Reports] CHECK CONSTRAINT [R_S]
GO
/****** Object:  StoredProcedure [dbo].[GetAll]    Script Date: 12/19/2020 8:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- exec GetAll 50,1
-- =============================================
CREATE PROCEDURE [dbo].[GetAll]
	-- Add the parameters for the stored procedure here
	@page int = null,
	@size int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Declare
	declare @start int = (@page-1)*@size +1;
	declare @end int =@page * @size;
    -- Insert statements for procedure here
	with s as(
	select ROW_NUMBER () over (Order by AssigneeTaskId) as STT, Assignees.AssigneeName, States.StateName, Tasks.TaskName, AssigneeTasks.Schedule 
		FROM (((AssigneeTasks
		INNER JOIN Assignees ON AssigneeTasks.AssigneeId = Assignees.AssigneeId)
		INNER JOIN States ON AssigneeTasks.StateId = States.StateId)
		INNER JOIN Tasks ON AssigneeTasks.TaskId = Tasks.TaskId))
	select * from s
	where STT>= @start and STT <=@end
END

GO
/****** Object:  StoredProcedure [dbo].[GetAllAssignees]    Script Date: 12/19/2020 8:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- exec GetAllAssignees
-- =============================================
CREATE PROCEDURE [dbo].[GetAllAssignees]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Declare
	
    -- Insert statements for procedure here

	select DISTINCT Assignees.AssigneeId, Assignees.AssigneeName
		FROM (AssigneeTasks
		INNER JOIN Assignees ON AssigneeTasks.AssigneeId = Assignees.AssigneeId)
		ORDER BY AssigneeId

		

END

GO
/****** Object:  StoredProcedure [dbo].[GetAllStates]    Script Date: 12/19/2020 8:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- exec GetAllStates
-- =============================================
CREATE PROCEDURE [dbo].[GetAllStates]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Declare
	
    -- Insert statements for procedure here

	select DISTINCT States.StateId, States.StateName
		FROM (AssigneeTasks
		INNER JOIN States ON AssigneeTasks.StateId = States.StateId)
		ORDER BY StateId

		

END

GO
/****** Object:  StoredProcedure [dbo].[GetAllTasks]    Script Date: 12/19/2020 8:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- exec GetAllTasks
-- =============================================
CREATE PROCEDURE [dbo].[GetAllTasks]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Declare
	
    -- Insert statements for procedure here

	select DISTINCT Tasks.TaskId, Tasks.TaskName
		FROM (AssigneeTasks
		INNER JOIN Tasks ON AssigneeTasks.TaskId = Tasks.TaskId)
		ORDER BY TaskId

END

GO
/****** Object:  StoredProcedure [dbo].[GetDistinctiveDate]    Script Date: 12/19/2020 8:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- exec GetDistinctiveDate
-- =============================================
CREATE PROCEDURE [dbo].[GetDistinctiveDate]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		SELECT DISTINCT Month(Schedule) as schedule
		FROM AssigneeTasks
		ORDER BY schedule ASC 
END


GO
/****** Object:  StoredProcedure [dbo].[getKeyWordSearchAssignee]    Script Date: 12/19/2020 8:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		
-- Create date: 2020-24-06
-- Description:	Nhap tu khoa de kiem Id theo Assignee. co phan trang
-- Run: exec getKeyWordSearchAssignee '',1,10
-- select * from Assignees
-- =============================================
CREATE PROCEDURE [dbo].[getKeyWordSearchAssignee]
	-- Add the parameters for the stored procedure here
	@key nvarchar(max) = null,
	@page int = null,
	@size int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @start int = (@page-1)*@size+1;
	declare @end int = @page*@size;
	with s as
	(
		select ROW_NUMBER () over (order by AssigneeId asc) as STT, *
		from Assignees
		where (AssigneeName like N'%' +@key + '%')
	)
	select *
	from s
	where STT >=@start and STT <= @end
END


GO
/****** Object:  StoredProcedure [dbo].[getKeyWordSearchAssigneeDepartment]    Script Date: 12/19/2020 8:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		
-- Create date: 2020-24-06
-- Description:	Nhap tu khoa de kiem Id theo Assignee. co phan trang
-- Run: exec getKeyWordSearchAssigneeDepartment '',1,10
-- select * from Assignees
-- =============================================
CREATE PROCEDURE [dbo].[getKeyWordSearchAssigneeDepartment]
	-- Add the parameters for the stored procedure here
	@key nvarchar(max) = null,
	@page int = null,
	@size int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @start int = (@page-1)*@size+1;
	declare @end int = @page*@size;
	with s as
	(
		select ROW_NUMBER () over (order by AssigneeDepartmentId asc) as STT, *
		from AssigneeDepartments
		where (AssigneeDepartmentId like N'%' +@key + '%' or AssigneeId like N'%' +@key + '%' or DepartmentId like N'%' +@key +'%')
	)
	select *
	from s
	where STT >=@start and STT <= @end
END


GO
/****** Object:  StoredProcedure [dbo].[getKeyWordSearchAssigneeTask]    Script Date: 12/19/2020 8:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		
-- Create date: 2020-24-06
-- Description:	Nhap tu khoa de kiem Id theo Assignee. co phan trang
-- Run: exec getKeyWordSearchAssigneeTask '',1,10
-- select * from Assignees
-- =============================================
CREATE PROCEDURE [dbo].[getKeyWordSearchAssigneeTask]
	-- Add the parameters for the stored procedure here
	@key nvarchar(max) = null,
	@page int = null,
	@size int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @start int = (@page-1)*@size+1;
	declare @end int = @page*@size;
	with s as
	(
		select ROW_NUMBER () over (order by AssigneeId asc) as STT, *
		from AssigneeTasks
		where (AssigneeId like N'%' +@key + '%' or TaskId like N'%' +@key +'%' or Schedule like N'%' +@key +'%')
	)
	select *
	from s
	where STT >=@start and STT <= @end
END


GO
/****** Object:  StoredProcedure [dbo].[getKeyWordSearchDepartment]    Script Date: 12/19/2020 8:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		
-- Create date: 2020-24-06
-- Description:	Nhap tu khoa de kiem Id theo Assignee. co phan trang
-- Run: exec getKeyWordSearchTask '',1,10
-- select * from Assignees
-- =============================================
CREATE PROCEDURE [dbo].[getKeyWordSearchDepartment]
	-- Add the parameters for the stored procedure here
	@key nvarchar(max) = null,
	@page int = null,
	@size int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @start int = (@page-1)*@size+1;
	declare @end int = @page*@size;
	with s as
	(
		select ROW_NUMBER () over (order by DepartmentId asc) as STT, *
		from Departments
		where (DepartmentName like N'%' +@key + '%')
	)
	select *
	from s
	where STT >=@start and STT <= @end
END


GO
/****** Object:  StoredProcedure [dbo].[getKeyWordSearchState]    Script Date: 12/19/2020 8:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		
-- Create date: 2020-24-06
-- Description:	Nhap tu khoa de kiem Id theo Assignee. co phan trang
-- Run: exec getKeyWordSearchAssignee '',1,10
-- select * from Assignees
-- =============================================
CREATE PROCEDURE [dbo].[getKeyWordSearchState]
	-- Add the parameters for the stored procedure here
	@key nvarchar(max) = null,
	@page int = null,
	@size int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @start int = (@page-1)*@size+1;
	declare @end int = @page*@size;
	with s as
	(
		select ROW_NUMBER () over (order by StateId asc) as STT, *
		from States
		where (StateName like N'%' +@key + '%')
	)
	select *
	from s
	where STT >=@start and STT <= @end
END

GO
/****** Object:  StoredProcedure [dbo].[getKeyWordSearchTask]    Script Date: 12/19/2020 8:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		
-- Create date: 2020-24-06
-- Description:	Nhap tu khoa de kiem Id theo Assignee. co phan trang
-- Run: exec getKeyWordSearchTask '',1,10
-- select * from Assignees
-- =============================================
CREATE PROCEDURE [dbo].[getKeyWordSearchTask]
	-- Add the parameters for the stored procedure here
	@key nvarchar(max) = null,
	@page int = null,
	@size int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @start int = (@page-1)*@size+1;
	declare @end int = @page*@size;
	with s as
	(
		select ROW_NUMBER () over (order by TaskId asc) as STT, *
		from Tasks
		where (TaskName like N'%' +@key + '%')
	)
	select *
	from s
	where STT >=@start and STT <= @end
END


GO
/****** Object:  StoredProcedure [dbo].[GetTotalByStateId]    Script Date: 12/19/2020 8:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- exec GetTotalByStateId
-- =============================================
Create PROCEDURE [dbo].[GetTotalByStateId]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		select *
		From Reports 
END


GO
/****** Object:  StoredProcedure [dbo].[GetTotalFor]    Script Date: 12/19/2020 8:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- exec GetTotalFor 3
-- =============================================
CREATE PROCEDURE [dbo].[GetTotalFor]
	-- Add the parameters for the stored procedure here
	@userid int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		SELECT COUNT(AssigneeTaskId) As Total
		FROM AssigneeTasks
		where StateId = @userid
		GROUP BY Month(Schedule)
		ORDER BY Month(Schedule) ASC
END


GO
/****** Object:  StoredProcedure [dbo].[GetTotalFor1]    Script Date: 12/19/2020 8:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- exec GetTotalFor1
-- =============================================
CREATE PROCEDURE [dbo].[GetTotalFor1]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		SELECT COUNT(AssigneeTaskId) As Total
		FROM AssigneeTasks
		where StateId = 1
		GROUP BY Month(Schedule)
		ORDER BY Month(Schedule) ASC
END


GO
/****** Object:  StoredProcedure [dbo].[GetTotalFor2]    Script Date: 12/19/2020 8:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- exec GetTotalFor2
-- =============================================
CREATE PROCEDURE [dbo].[GetTotalFor2]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		SELECT COUNT(AssigneeTaskId) As Total
		FROM AssigneeTasks
		where StateId = 2
		GROUP BY Month(Schedule)
		ORDER BY Month(Schedule) ASC
END


GO
/****** Object:  StoredProcedure [dbo].[GetTotalFor3]    Script Date: 12/19/2020 8:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- exec GetTotalFor3
-- =============================================
CREATE PROCEDURE [dbo].[GetTotalFor3]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		SELECT COUNT(AssigneeTaskId) As Total
		FROM AssigneeTasks
		where StateId = 3
		GROUP BY Month(Schedule)
		ORDER BY Month(Schedule) ASC
END


GO
/****** Object:  StoredProcedure [dbo].[GetTotalFor4]    Script Date: 12/19/2020 8:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- exec GetTotalFor4
-- =============================================
CREATE PROCEDURE [dbo].[GetTotalFor4]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		SELECT COUNT(AssigneeTaskId) As Total
		FROM AssigneeTasks
		where StateId = 4
		GROUP BY Month(Schedule)
		ORDER BY Month(Schedule) ASC
END


GO
/****** Object:  StoredProcedure [dbo].[spSel_getKeyWordSearchCommunity]    Script Date: 12/19/2020 8:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		
-- Create date: 2020-24-06
-- Description:	Nhap tu khoa de kiem Id theo Assignee. co phan trang
-- Run: exec spSel_getKeyWordSearchCommunity 'HC20000000006',1,10
-- =============================================
CREATE PROCEDURE [dbo].[spSel_getKeyWordSearchCommunity]
	-- Add the parameters for the stored procedure here
	@key nvarchar(30) =null,
	@page int = null,
	@size int =null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @start int = (@page-1)*@size+1;
	declare @end int = @page*@size;
	with s as
	(
		select ROW_NUMBER () over (order by Id asc) as STT, *
		from Communities
		where (Assignee like '%'  +@key+'%' or TaskName like '%'  +@key+'%' or TaskState like '%'  +@key+'%' )
	)
	select *
	from s
	where STT >=@start and STT <= @end
END


GO
USE [master]
GO
ALTER DATABASE [Data] SET  READ_WRITE 
GO
