USE [Nexos]
GO
/****** Object:  Table [dbo].[Autor]    Script Date: 28/07/2022 16:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autor](
	[idAutor] [int] IDENTITY(1,1) NOT NULL,
	[nombreAutor] [nvarchar](200) NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
	[ciudadProcedencia] [nvarchar](100) NOT NULL,
	[correo] [nvarchar](400) NOT NULL,
 CONSTRAINT [PK_Autor] PRIMARY KEY CLUSTERED 
(
	[idAutor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libro]    Script Date: 28/07/2022 16:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libro](
	[idLibro] [int] IDENTITY(1,1) NOT NULL,
	[titulo] [nvarchar](400) NULL,
	[genero] [nvarchar](200) NULL,
	[numeroPaginas] [int] NULL,
	[idAutor] [int] NOT NULL,
	[anio] [int] NOT NULL,
 CONSTRAINT [PK_Libro] PRIMARY KEY CLUSTERED 
(
	[idLibro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Autor] ON 

INSERT [dbo].[Autor] ([idAutor], [nombreAutor], [fechaNacimiento], [ciudadProcedencia], [correo]) VALUES (8, N'Gustave Flaubert', CAST(N'1821-12-12' AS Date), N'Ruan', N'Gustave22@mail.com')
INSERT [dbo].[Autor] ([idAutor], [nombreAutor], [fechaNacimiento], [ciudadProcedencia], [correo]) VALUES (9, N'Gabriel García Márquez', CAST(N'1927-03-06' AS Date), N'Mexico', N'gabriel@gmail.com')
SET IDENTITY_INSERT [dbo].[Autor] OFF
GO
SET IDENTITY_INSERT [dbo].[Libro] ON 

INSERT [dbo].[Libro] ([idLibro], [titulo], [genero], [numeroPaginas], [idAutor], [anio]) VALUES (11, N'Cien años de soledad', N'Novela', 471, 9, 1965)
INSERT [dbo].[Libro] ([idLibro], [titulo], [genero], [numeroPaginas], [idAutor], [anio]) VALUES (12, N'La educación sentimental', N'Novela', 478, 8, 1869)
INSERT [dbo].[Libro] ([idLibro], [titulo], [genero], [numeroPaginas], [idAutor], [anio]) VALUES (13, N'El amor en los tiempos del cólera', N'Narrativo', 490, 9, 1985)
INSERT [dbo].[Libro] ([idLibro], [titulo], [genero], [numeroPaginas], [idAutor], [anio]) VALUES (14, N'asd', N'J', 471, 9, 1965)
SET IDENTITY_INSERT [dbo].[Libro] OFF
GO
ALTER TABLE [dbo].[Libro]  WITH CHECK ADD FOREIGN KEY([idAutor])
REFERENCES [dbo].[Autor] ([idAutor])
GO
