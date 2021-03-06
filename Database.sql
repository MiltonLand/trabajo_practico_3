USE [master]
GO
/****** Object:  Database [DBTP3]    Script Date: 12/12/2017 11:19:52 ******/
CREATE DATABASE [DBTP3]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBTP3', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DBTP3.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DBTP3_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DBTP3_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DBTP3] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBTP3].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBTP3] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBTP3] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBTP3] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBTP3] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBTP3] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBTP3] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBTP3] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [DBTP3] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBTP3] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBTP3] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBTP3] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBTP3] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBTP3] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBTP3] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBTP3] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBTP3] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBTP3] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBTP3] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBTP3] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBTP3] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBTP3] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBTP3] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBTP3] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBTP3] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DBTP3] SET  MULTI_USER 
GO
ALTER DATABASE [DBTP3] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBTP3] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBTP3] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBTP3] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [DBTP3]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 12/12/2017 11:19:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employees]    Script Date: 12/12/2017 11:19:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[CountryID] [int] NOT NULL,
	[Shift] [nvarchar](50) NULL,
	[HiringDate] [datetime] NULL,
	[HourlyWage] [decimal](6, 2) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkingDay]    Script Date: 12/12/2017 11:19:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkingDay](
	[WorkingDayID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[TimeIn] [datetime] NOT NULL,
	[TimeOut] [datetime] NULL,
	[HoursWorked] [decimal](4, 2) NULL CHECK (HoursWorked > 0 AND HoursWorked < 24),
PRIMARY KEY CLUSTERED 
(
	[WorkingDayID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Country] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Country] ([CountryID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Country]
GO
ALTER TABLE [dbo].[WorkingDay]  WITH CHECK ADD FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
USE [master]
GO
ALTER DATABASE [DBTP3] SET  READ_WRITE 
GO
