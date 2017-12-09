USE [BDTP3]
GO


/****** Object:  Table [dbo].[Empleados]    Script Date: 11/27/2017 8:25:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[EmpleadoID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[PaisID] [int] NOT NULL,
	
	[FechaIngreso] [datetime] NULL,

 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[EmpleadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pais]    Script Date: 11/27/2017 8:25:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paises](
	[PaisID] [int] IDENTITY(1,1) NOT NULL,
	[NombrePais] [nvarchar](20) NOT NULL,
	
 CONSTRAINT [PK_Paises] PRIMARY KEY CLUSTERED 
(
	[PaisID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 



ALTER TABLE [dbo].[Empleados] ADD 
	CONSTRAINT [FK_Empleados_Paises] FOREIGN KEY 
	(
		[PaisID]
	) REFERENCES [dbo].[Paises] (
		[PaisID]
	)

   
GO
SET IDENTITY_INSERT [dbo].[Paises] ON 

INSERT [dbo].[Paises] ([PaisID], [NombrePais]) VALUES (1, N'Argentina')
INSERT [dbo].[Paises] ([PaisID], [NombrePais]) VALUES (2, N'Brasil')
GO
SET IDENTITY_INSERT [dbo].[Paises] OFF 


SET IDENTITY_INSERT [dbo].[Empleados] ON 
INSERT [dbo].[Empleados] ([EmpleadoID], [Nombre], [Apellido], [PaisID],[FechaIngreso]) VALUES (1, N'Juan', N'Perez',1,'2017/10/10 12:00:00 AM')
GO


