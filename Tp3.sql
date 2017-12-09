USE [DBTP3]
GO


/****** Object:  Table [dbo].[Turnos]    Script Date: 11/27/2017 8:25:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turns](
	[TurnID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](25) NOT NULL,
	[TimeIn] [time] NOT NULL,
	[TimeOut] [time] NOT NULL,
	
 CONSTRAINT [PK_Turns] PRIMARY KEY CLUSTERED 
(
	[TurnID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Empleados]    Script Date: 11/27/2017 8:25:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[CountryID] [int] NOT NULL,
	[TurnID][int] NOT NULL,
	[HireDate] [datetime] NULL,


 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pais]    Script Date: 11/27/2017 8:25:22 AM ******/
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



ALTER TABLE [dbo].[Employees] ADD 
	CONSTRAINT [FK_Employees_Country] FOREIGN KEY 
	(
		[CountryID]
	) REFERENCES [dbo].[Country] (
		[CountryID]
	)

   
GO
ALTER TABLE [dbo].[Employees] ADD 
	CONSTRAINT [FK_Employee_Turns] FOREIGN KEY 
	(
		[TurnID]
	) REFERENCES [dbo].[Turns] (
		[TurnID]
	)

   
GO
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([CountryID], [CountryName]) VALUES (1, N'Argentina')
INSERT [dbo].[Country] ([CountryID], [CountryName]) VALUES (2, N'Brasil')
GO
SET IDENTITY_INSERT [dbo].[Country] OFF 



SET IDENTITY_INSERT [dbo].[Turns] ON 

INSERT [dbo].[Turns] ([TurnID], [Description],[TimeIn],[TimeOut]) VALUES (1, N'Mañana','09:00:00','16:00:00')

INSERT [dbo].[Turns] ([TurnID], [Description],[TimeIn],[TimeOut])  VALUES (2, N'Tarde','16:00:00','00:00:00')

INSERT [dbo].[Turns] ([TurnID], [Description],[TimeIn],[TimeOut])  VALUES (3, N'Noche','00:00:00','09:00:00')
GO
SET IDENTITY_INSERT [dbo].[Turns] OFF 


SET IDENTITY_INSERT [dbo].[Employees] ON 
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [CountryID],[TurnID],[HireDate]) VALUES (1, N'Juan', N'Perez',1,1,'2017/10/10 12:00:00 AM')
GO


