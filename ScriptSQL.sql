--CREANDO LA BASE DE DATOS
CREATE DATABASE HelpDeskDB
﻿USE [HelpDeskDB]
GO
/****** Object:  Table [dbo].[Problemas]    Script Date: 03/04/2016 16:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Problemas](
	[IdProblema] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProblema] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 03/04/2016 16:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Estado](
	[IdEstado] [int] IDENTITY(1,1) NOT NULL,
	[Estado] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEstado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Departamentos]    Script Date: 03/04/2016 16:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Departamentos](
	[IdDepartment] [int] IDENTITY(1,1) NOT NULL,
	[Departamento] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDepartment] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoUser]    Script Date: 03/04/2016 16:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoUser](
	[IdTipoUsuario] [int] IDENTITY(1,1) NOT NULL,
	[TipoUsuario] [varchar](50) NULL,
 CONSTRAINT [PK_ITSoporte] PRIMARY KEY CLUSTERED 
(
	[IdTipoUsuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoSolicitud]    Script Date: 03/04/2016 16:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoSolicitud](
	[IdSolicitud] [int] IDENTITY(1,1) NOT NULL,
	[TipoSolicitud] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdSolicitud] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Severidad]    Script Date: 03/04/2016 16:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Severidad](
	[IdSeveridad] [int] IDENTITY(1,1) NOT NULL,
	[Severidad] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdSeveridad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RegistroUsuario]    Script Date: 03/04/2016 16:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RegistroUsuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdTipoUsuario] [int] NULL,
	[NombreUsuario] [varchar](50) NULL,
	[PrimerNombre] [varchar](50) NULL,
	[SegundoNombre] [varchar](50) NULL,
	[Contrasena] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[DepartamentId] [int] NULL,
 CONSTRAINT [PK__Registro__3214EC071FCDBCEB] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RegistroSoporte]    Script Date: 03/04/2016 16:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RegistroSoporte](
	[IdSoporte] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[FechaRegistro] [datetime] NULL,
	[DescripcionProblema] [varchar](100) NULL,
	[DepartamentId] [int] NULL,
	[IdProblem] [int] NULL,
	[IdTipoSolicitud] [int] NULL,
	[IdEstado] [int] NULL,
	[IdSeveridad] [int] NULL,
	[IdTecnico] [int] NULL,
	[ImagePath] [varchar](100) NULL,
	[AsignadoPor] [int] NULL,
	[CerradoPor] [int] NULL,
 CONSTRAINT [PK__Registro__3214EC0707020F21] PRIMARY KEY CLUSTERED 
(
	[IdSoporte] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[GetListTipoUsers]    Script Date: 03/04/2016 16:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetListTipoUsers]
  as select * from dbo.TipoUser
GO
/****** Object:  StoredProcedure [dbo].[GetListSeverida]    Script Date: 03/04/2016 16:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetListSeverida]
  as select * from dbo.Severidad
GO
/****** Object:  StoredProcedure [dbo].[GetListEstados]    Script Date: 03/04/2016 16:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetListEstados]
  as select * from dbo.Estado
GO
/****** Object:  StoredProcedure [dbo].[GetDeparments]    Script Date: 03/04/2016 16:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetDeparments]
	as select * from Departamentos
GO
/****** Object:  StoredProcedure [dbo].[GetUsuarios]    Script Date: 03/04/2016 16:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetUsuarios]
  as select * from dbo.RegistroUsuario
GO
/****** Object:  StoredProcedure [dbo].[GetTecnicos]    Script Date: 03/04/2016 16:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetTecnicos]
  as select * from dbo.RegistroUsuario
  where IdTipoUsuario = 2 or IdTipoUsuario = 3
GO
/****** Object:  StoredProcedure [dbo].[GetSolicitudes]    Script Date: 03/04/2016 16:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetSolicitudes]
as select * from dbo.TipoSolicitud
GO
/****** Object:  StoredProcedure [dbo].[GetProblems]    Script Date: 03/04/2016 16:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetProblems]
as select * from dbo.Problemas
GO
/****** Object:  StoredProcedure [dbo].[GetOneUsuario]    Script Date: 03/04/2016 16:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetOneUsuario]
  (
  @id int
  )
  as 
  select top 1 Id,IdTipoUsuario,NombreUsuario,PrimerNombre, SegundoNombre from dbo.RegistroUsuario where Id=@id
GO
/****** Object:  StoredProcedure [dbo].[LoginUser]    Script Date: 03/04/2016 16:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[LoginUser]
  (
  @username varchar(50),
  @pass varchar(50)
  )
	as
	begin
		select top 1 Id,IdTipoUsuario,PrimerNombre,SegundoNombre,Email, NombreUsuario,Contrasena,DepartamentId
		from dbo.RegistroUsuario
		WHERE NombreUsuario=@username and Contrasena=@pass
		end
GO
/****** Object:  StoredProcedure [dbo].[InsertUsuario]    Script Date: 03/04/2016 16:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertUsuario]
(
@NombreUsuario varchar(50)
,@IdTipoUsuario int
,@PrimerNombre varchar(50)
,@SegundoNombre varchar(50)
,@Contrasena varchar(50)
,@Email varchar(50)
,@DepartmentId int
,@NewId int output
)
AS 
	INSERT INTO dbo.RegistroUsuario
	(NombreUsuario,IdTipoUsuario,PrimerNombre,SegundoNombre,Contrasena,Email,DepartamentId)
	VALUES(@NombreUsuario,@IdTipoUsuario,@PrimerNombre,@SegundoNombre,@Contrasena,@Email,@DepartmentId)	
	set @newID = scope_identity()		
	return @newID
GO
/****** Object:  StoredProcedure [dbo].[UpdateUsuario]    Script Date: 03/04/2016 16:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUsuario]
(
@IdUsuario int
,@NombreUsuario varchar(50)
,@PrimerNombre varchar(50)
,@SegundoNombre varchar(50)
,@Contrasena varchar(50)
,@Email varchar(50)
,@DepartmentId int
)
AS 
	UPDATE dbo.RegistroUsuario
	SET NombreUsuario=@NombreUsuario,PrimerNombre=@PrimerNombre,SegundoNombre=@SegundoNombre,
	Contrasena=@Contrasena,Email=@Email,DepartmentId=@DepartmentId
	WHERE Id=@IdUsuario
GO
/****** Object:  StoredProcedure [dbo].[UpdateSoporte]    Script Date: 03/04/2016 16:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateSoporte]
  (
  @IdSoporte int,
  @FechaRegistro date,
  @DescripcionProblema varchar(100),
  @DepartamentId int,
  @IdProblem int,
  @IdTipoSolicitud int,
  @IdEstado int,
  @IdPrioridad int,
  @imagepath varchar(100)=null
  )
  AS
	UPDATE dbo.RegistroSoporte
	SET FechaRegistro = @FechaRegistro,
	DescripcionProblema = @DescripcionProblema,DepartamentId=@DepartamentId,
	IdProblem=@IdProblem,IdTipoSolicitud=@IdTipoSolicitud,IdEstado=@IdEstado,
	IdSeveridad=@IdPrioridad,ImagePath=@imagepath
	where IdSoporte=@IdSoporte
GO
/****** Object:  StoredProcedure [dbo].[InsertSoporte]    Script Date: 03/04/2016 16:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertSoporte]
  (
  @IdUsuario int,
  @FechaRegistro date,
  @DescripcionProblema varchar(100),
  @DepartamentId int,
  @IdProblem int,
  @IdTipoSolicitud int,
  @IdEstado int,
  @IdPrioridad int,
  @imagepath varchar(100)=null,
  @NewId int output
  )
  AS
	INSERT INTO dbo.RegistroSoporte
	(IdUsuario,FechaRegistro,DescripcionProblema,DepartamentId,
	IdProblem,IdTipoSolicitud,IdEstado,IdSeveridad,ImagePath) VALUES
	(@IdUsuario,@FechaRegistro,@DescripcionProblema,
	@DepartamentId,@IdProblem,@IdTipoSolicitud,@IdEstado,@IdPrioridad,@imagepath)
	set @newID = scope_identity()		
	return @newID
GO
/****** Object:  StoredProcedure [dbo].[GetOneSoporte]    Script Date: 03/04/2016 16:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetOneSoporte](@Id int)
as select top 1 IdSoporte,
IdUsuario,FechaRegistro,DescripcionProblema,DepartamentId,IdProblem,IdTipoSolicitud,
sp.IdEstado,SP.IdSeveridad,IdTecnico,ImagePath, TP.TipoSolicitud,DP.Departamento,ES.Estado,
SV.Severidad, PR.Descripcion as Problema
 from dbo.RegistroSoporte SP
join dbo.TipoSolicitud TP on SP.IdTipoSolicitud = TP.IdSolicitud
join dbo.Departamentos DP on SP.DepartamentId = DP.IdDepartment
join dbo.Estado ES on SP.IdEstado = ES.IdEstado
join dbo.Severidad SV on SP.IdSeveridad = SV.IdSeveridad
join dbo.Problemas PR on SP.IdProblem = PR.IdProblema
where IdSoporte = @Id
GO
/****** Object:  StoredProcedure [dbo].[DeleteSoporte]    Script Date: 03/04/2016 16:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteSoporte]
  (
  @id int
  )
  as
	delete from dbo.RegistroSoporte
	where IdSoporte =@id
GO
/****** Object:  StoredProcedure [dbo].[ConsultaMasivaSoporte]    Script Date: 03/04/2016 16:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[ConsultaMasivaSoporte]    Script Date: 03/04/2016 09:42:57 ******/

CREATE PROCEDURE [dbo].[ConsultaMasivaSoporte]
(
 @IdSoporte int=null
,@DescripcionProblema varchar(200)=null
,@FechaRegistro datetime=null
,@Department int=null
,@IdTipoSolicitud int=null
,@IdEstado int=null
,@IdSeveridad int=null
)
as	
       select
		IdSoporte,
		IdUsuario,
		DescripcionProblema,
		FechaRegistro,
		IdTipoSolicitud,
		SP.DepartamentId,
		sp.IdEstado,
		sp.IdSeveridad,
		dp.Departamento,
		 EST.Estado,
		SV.Severidad,
		TS.TipoSolicitud,
		usr.NombreUsuario,
		rgu.NombreUsuario as UsuarioAsignador,
		SP.IdTecnico,
		TeCAsig.NombreUsuario as TecnicoAsignado,
		RES.NombreUsuario as Cerrador
		 FROM dbo.RegistroSoporte SP
		 JOIN dbo.Departamentos dp on SP.DepartamentId = dp.IdDepartment
	     join dbo.Estado EST on SP.IdEstado = EST.IdEstado
	     join dbo.Severidad SV on SP.idseveridad = SV.idseveridad
	     join dbo.TipoSolicitud TS on SP.IdTipoSolicitud = TS.IdSolicitud
	     join dbo.RegistroUsuario usr on SP.IdUsuario = usr.Id
	     left join RegistroUsuario rgu on SP.AsignadoPor = rgu.Id
	     left join RegistroUsuario RES on SP.CerradoPor = RES.Id
	     left join RegistroUsuario TeCAsig on SP.IdTecnico = TeCAsig.Id
		 WHERE((@IdSoporte is null) or(IdSoporte = @IdSoporte)) and
		((@DescripcionProblema is null) or (DescripcionProblema like '%'+@DescripcionProblema+'%'))and
		((@FechaRegistro IS NULL) OR(CAST (FechaRegistro AS DATE)= @FechaRegistro))AND
		((@Department is null) or(IdDepartment=@Department))and
		((@IdEstado is null) or(sp.IdEstado=@IdEstado))and
		((@IdSeveridad is null)or(sp.IdSeveridad=@IdSeveridad))and
		((@IdTipoSolicitud is null) or(IdTipoSolicitud=@IdTipoSolicitud))
GO
/****** Object:  StoredProcedure [dbo].[CerrarTciket]    Script Date: 03/04/2016 16:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[CerrarTciket]
(@idsoporte int
)
as 
update dbo.RegistroSoporte
set IdEstado=3
where IdSoporte=@idsoporte
GO
/****** Object:  StoredProcedure [dbo].[AsingarTicketToTecnico]    Script Date: 03/04/2016 16:33:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AsingarTicketToTecnico]
(@idticket int,
@idtecnico int,
@asignadopor int

)
as 
update dbo.RegistroSoporte
set IdTecnico=@idtecnico,IdEstado=2,AsignadoPor=@asignadopor
where IdSoporte=@idticket
GO
/****** Object:  ForeignKey [FK_RegistroSoporte_Departamentos1]    Script Date: 03/04/2016 16:33:22 ******/
ALTER TABLE [dbo].[RegistroSoporte]  WITH CHECK ADD  CONSTRAINT [FK_RegistroSoporte_Departamentos1] FOREIGN KEY([DepartamentId])
REFERENCES [dbo].[Departamentos] ([IdDepartment])
GO
ALTER TABLE [dbo].[RegistroSoporte] CHECK CONSTRAINT [FK_RegistroSoporte_Departamentos1]
GO
/****** Object:  ForeignKey [FK_RegistroSoporte_Estado]    Script Date: 03/04/2016 16:33:22 ******/
ALTER TABLE [dbo].[RegistroSoporte]  WITH CHECK ADD  CONSTRAINT [FK_RegistroSoporte_Estado] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[Estado] ([IdEstado])
GO
ALTER TABLE [dbo].[RegistroSoporte] CHECK CONSTRAINT [FK_RegistroSoporte_Estado]
GO
/****** Object:  ForeignKey [FK_RegistroSoporte_Problemas]    Script Date: 03/04/2016 16:33:22 ******/
ALTER TABLE [dbo].[RegistroSoporte]  WITH CHECK ADD  CONSTRAINT [FK_RegistroSoporte_Problemas] FOREIGN KEY([IdProblem])
REFERENCES [dbo].[Problemas] ([IdProblema])
GO
ALTER TABLE [dbo].[RegistroSoporte] CHECK CONSTRAINT [FK_RegistroSoporte_Problemas]
GO
/****** Object:  ForeignKey [FK_RegistroSoporte_Severidad]    Script Date: 03/04/2016 16:33:22 ******/
ALTER TABLE [dbo].[RegistroSoporte]  WITH CHECK ADD  CONSTRAINT [FK_RegistroSoporte_Severidad] FOREIGN KEY([IdSeveridad])
REFERENCES [dbo].[Severidad] ([IdSeveridad])
GO
ALTER TABLE [dbo].[RegistroSoporte] CHECK CONSTRAINT [FK_RegistroSoporte_Severidad]
GO
/****** Object:  ForeignKey [FK_RegistroSoporte_TipoSolicitud]    Script Date: 03/04/2016 16:33:22 ******/
ALTER TABLE [dbo].[RegistroSoporte]  WITH CHECK ADD  CONSTRAINT [FK_RegistroSoporte_TipoSolicitud] FOREIGN KEY([IdTipoSolicitud])
REFERENCES [dbo].[TipoSolicitud] ([IdSolicitud])
GO
ALTER TABLE [dbo].[RegistroSoporte] CHECK CONSTRAINT [FK_RegistroSoporte_TipoSolicitud]
GO
INSERT INTO  dbo.Estado(Estado) values ('Nueva')
INSERT INTO  dbo.Estado(Estado) values ('Abierta')
INSERT INTO  dbo.Estado(Estado) values ('Cerrada')
INSERT INTO  dbo.Problemas(Descripcion) values ('Configuracion Impresora')
INSERT INTO  dbo.Problemas(Descripcion) values ('Conexion a Internet')
INSERT INTO  dbo.Problemas(Descripcion) values ('Problema General PC')
INSERT INTO  dbo.Problemas(Descripcion) values ('Error al iniciar sesion')
INSERT INTO dbo.Departamentos (Departamento) values ('Tecnologia')
INSERT INTO dbo.Departamentos (Departamento) values ('Servicio al Cliente')
INSERT INTO dbo.Departamentos (Departamento) values ('Recursos Humanos')
INSERT INTO dbo.Severidad (Severidad) VALUES ('Baja')
INSERT INTO dbo.Severidad (Severidad) VALUES ('Mediana')
INSERT INTO dbo.Severidad (Severidad) VALUES ('Alta')
INSERT INTO  dbo.TipoSolicitud(TipoSolicitud) VALUES ('Desarrollo')
INSERT INTO  dbo.TipoSolicitud(TipoSolicitud) VALUES ('Soporte')
insert into dbo.TipoUser (TipoUsuario) values('Usuario')
insert into dbo.TipoUser (TipoUsuario) values('IT Soporte')
insert into dbo.TipoUser (TipoUsuario) values('Admin')
INSERT INTO dbo.RegistroUsuario (IdTipoUsuario,NombreUsuario,PrimerNombre,SegundoNombre,Contrasena,Email,DepartamentId)values(3,'jozoria','Juan','Carlos','123456','jc@gg.com',1)
INSERT INTO dbo.RegistroUsuario (IdTipoUsuario,NombreUsuario,PrimerNombre,SegundoNombre,Contrasena,Email,DepartamentId)values(2,'joseline','joseline','lora','123456','jj@jj.com',2)
INSERT INTO dbo.RegistroUsuario (IdTipoUsuario,NombreUsuario,PrimerNombre,SegundoNombre,Contrasena,Email,DepartamentId)values(2,'abatista','ariel','batista','123456','aa@jj.com',2)
INSERT INTO dbo.RegistroUsuario (IdTipoUsuario,NombreUsuario,PrimerNombre,SegundoNombre,Contrasena,Email,DepartamentId)values(1,'natalie','natalie','luz','123456','nq@jj.com',3)
INSERT INTO dbo.RegistroSoporte (IdUsuario,FechaRegistro,DescripcionProblema,DepartamentId,IdProblem,IdTipoSolicitud,IdEstado,IdSeveridad)
values(1,GETDATE(),'Problemas de redes',3,1,2,1,2)



