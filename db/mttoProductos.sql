USE [Mantenimiento_Productos]
GO
/****** Object:  Table [dbo].[categoria]    Script Date: 11/05/2021 18:11:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categoria](
	[idCategoria] [int] IDENTITY(1,1) NOT NULL,
	[codigo]  AS ('CT'+right('00'+CONVERT([varchar],[idCategoria]),(2))),
	[nombre] [nvarchar](30) NOT NULL,
	[descripcion] [nvarchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[idCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_BuscarCategoria]    Script Date: 11/05/2021 18:11:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_BuscarCategoria]
@Buscar nvarchar(20)
as
select * from categoria
where nombre like @Buscar + '%'
GO
/****** Object:  StoredProcedure [dbo].[sp_EditarCategoria]    Script Date: 11/05/2021 18:11:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_EditarCategoria]
@IdCategoria int,
@Nombre nvarchar(30),
@descripcion nvarchar(256)
as
UPDATE categoria set nombre=@Nombre, descripcion=@descripcion
WHERE idCategoria=@IdCategoria
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarCategoria]    Script Date: 11/05/2021 18:11:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_EliminarCategoria]
@IdCategoria int
as
delete categoria
where idCategoria=@IdCategoria
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarCategoria]    Script Date: 11/05/2021 18:11:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_InsertarCategoria]
@Nombre nvarchar(30),
@Descripcion nvarchar(256)
as
insert into categoria values (@Nombre,@Descripcion)
GO
