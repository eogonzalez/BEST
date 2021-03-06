USE [BESTDB]
GO
/****** Object:  Schema [BEST]    Script Date: 08/03/2015 23:18:59 ******/
CREATE SCHEMA [BEST] AUTHORIZATION [dbo]
GO
/****** Object:  Table [BEST].[G_C_Tipo_Suscripcion]    Script Date: 08/03/2015 23:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [BEST].[G_C_Tipo_Suscripcion](
	[id_tipo_suscripcion] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](300) NULL,
	[estado] [char](1) NOT NULL,
 CONSTRAINT [PK_G_C_Tipo_Suscripcion] PRIMARY KEY CLUSTERED 
(
	[id_tipo_suscripcion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [BEST].[G_C_Roles]    Script Date: 08/03/2015 23:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [BEST].[G_C_Roles](
	[id_rol] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](300) NULL,
	[fecha_registro] [datetime] NOT NULL,
	[rol_del_sistema] [bit] NOT NULL,
	[estado] [char](1) NOT NULL,
 CONSTRAINT [PK_G_C_Roles] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [BEST].[G_C_Modulos]    Script Date: 08/03/2015 23:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [BEST].[G_C_Modulos](
	[id_modulo] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](300) NULL,
	[path] [varchar](max) NULL,
	[estado] [char](1) NOT NULL,
 CONSTRAINT [PK_G_C_Modulos] PRIMARY KEY CLUSTERED 
(
	[id_modulo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [BEST].[G_C_Empresa]    Script Date: 08/03/2015 23:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [BEST].[G_C_Empresa](
	[id_empresa] [int] NOT NULL,
	[razon_social] [varchar](200) NOT NULL,
	[nombre_comercial] [varchar](200) NOT NULL,
	[direccion] [varchar](100) NULL,
	[email] [varchar](50) NULL,
	[telefono] [varchar](50) NULL,
	[fecha_registro] [datetime] NOT NULL,
	[estado] [char](1) NOT NULL,
 CONSTRAINT [PK_G_C_Empresa] PRIMARY KEY CLUSTERED 
(
	[id_empresa] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [BEST].[G_D_Empresa_Roles]    Script Date: 08/03/2015 23:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [BEST].[G_D_Empresa_Roles](
	[id_empresa] [int] NOT NULL,
	[id_rol] [int] NOT NULL,
	[fecha_registro] [datetime] NOT NULL,
	[estado] [char](1) NOT NULL,
 CONSTRAINT [PK_G_D_Empresa_Roles] PRIMARY KEY CLUSTERED 
(
	[id_empresa] ASC,
	[id_rol] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [BEST].[G_D_Empresa_Modulo]    Script Date: 08/03/2015 23:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [BEST].[G_D_Empresa_Modulo](
	[id_empresa] [int] NOT NULL,
	[id_modulo] [int] NOT NULL,
	[fecha_registro] [datetime] NOT NULL,
	[estado] [char](1) NOT NULL,
 CONSTRAINT [PK_G_D_Empresa_Modulo] PRIMARY KEY CLUSTERED 
(
	[id_empresa] ASC,
	[id_modulo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [BEST].[G_C_Usuario]    Script Date: 08/03/2015 23:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [BEST].[G_C_Usuario](
	[id_empresa] [int] NOT NULL,
	[id_usuario] [int] NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[correo] [varchar](50) NOT NULL,
	[fecha_registro] [datetime] NOT NULL,
	[estado] [char](1) NOT NULL,
 CONSTRAINT [PK_G_C_Usuario] PRIMARY KEY CLUSTERED 
(
	[id_empresa] ASC,
	[id_usuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_G_C_Usuario] UNIQUE NONCLUSTERED 
(
	[id_empresa] ASC,
	[correo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [BEST].[G_D_Usuario_Roles]    Script Date: 08/03/2015 23:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [BEST].[G_D_Usuario_Roles](
	[id_empresa] [int] NOT NULL,
	[id_usuario] [int] NOT NULL,
	[id_rol] [int] NOT NULL,
	[fecha_registro] [datetime] NOT NULL,
	[estado] [char](1) NOT NULL,
 CONSTRAINT [PK_G_D_Usuario_Roles] PRIMARY KEY CLUSTERED 
(
	[id_empresa] ASC,
	[id_usuario] ASC,
	[id_rol] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [BEST].[G_D_Usuario_Password]    Script Date: 08/03/2015 23:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [BEST].[G_D_Usuario_Password](
	[id_usuario_password] [bigint] NOT NULL,
	[id_empresa] [int] NOT NULL,
	[id_usuario] [int] NOT NULL,
	[password] [varchar](max) NOT NULL,
	[fecha_registro] [datetime] NOT NULL,
	[estado] [char](1) NOT NULL,
 CONSTRAINT [PK_G_D_Usuario_Password] PRIMARY KEY CLUSTERED 
(
	[id_usuario_password] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [BEST].[G_D_Usuario_Acceso]    Script Date: 08/03/2015 23:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [BEST].[G_D_Usuario_Acceso](
	[id_usuario_acceso] [bigint] NOT NULL,
	[id_empresa] [int] NOT NULL,
	[id_usuario] [int] NOT NULL,
	[fecha_registro] [datetime] NOT NULL,
	[ip] [varchar](100) NOT NULL,
 CONSTRAINT [PK_G_D_Usuario_Acceso] PRIMARY KEY CLUSTERED 
(
	[id_usuario_acceso] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [BEST].[G_D_Suscripcion]    Script Date: 08/03/2015 23:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [BEST].[G_D_Suscripcion](
	[id_suscripcion] [bigint] IDENTITY(1,1) NOT NULL,
	[id_empresa] [int] NOT NULL,
	[id_usuario] [int] NOT NULL,
	[id_tipo_suscripcion] [int] NOT NULL,
	[fecha_inicio] [date] NOT NULL,
	[fecha_fin] [date] NOT NULL,
	[fecha_registro] [datetime] NOT NULL,
	[estado] [char](1) NULL,
 CONSTRAINT [PK_G_D_Suscripcion] PRIMARY KEY CLUSTERED 
(
	[id_suscripcion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF_G_C_Empresa_fecha_registro]    Script Date: 08/03/2015 23:18:59 ******/
ALTER TABLE [BEST].[G_C_Empresa] ADD  CONSTRAINT [DF_G_C_Empresa_fecha_registro]  DEFAULT (getdate()) FOR [fecha_registro]
GO
/****** Object:  Default [DF_G_C_Empresa_estado]    Script Date: 08/03/2015 23:18:59 ******/
ALTER TABLE [BEST].[G_C_Empresa] ADD  CONSTRAINT [DF_G_C_Empresa_estado]  DEFAULT ('A') FOR [estado]
GO
/****** Object:  Default [DF_G_C_Modulos_estado]    Script Date: 08/03/2015 23:18:59 ******/
ALTER TABLE [BEST].[G_C_Modulos] ADD  CONSTRAINT [DF_G_C_Modulos_estado]  DEFAULT ('A') FOR [estado]
GO
/****** Object:  Default [DF_G_C_Roles_fecha_registro]    Script Date: 08/03/2015 23:18:59 ******/
ALTER TABLE [BEST].[G_C_Roles] ADD  CONSTRAINT [DF_G_C_Roles_fecha_registro]  DEFAULT (getdate()) FOR [fecha_registro]
GO
/****** Object:  Default [DF_G_C_Roles_rol_del_sistema]    Script Date: 08/03/2015 23:18:59 ******/
ALTER TABLE [BEST].[G_C_Roles] ADD  CONSTRAINT [DF_G_C_Roles_rol_del_sistema]  DEFAULT ((0)) FOR [rol_del_sistema]
GO
/****** Object:  Default [DF_G_C_Roles_estado]    Script Date: 08/03/2015 23:18:59 ******/
ALTER TABLE [BEST].[G_C_Roles] ADD  CONSTRAINT [DF_G_C_Roles_estado]  DEFAULT ('A') FOR [estado]
GO
/****** Object:  Default [DF_G_C_Tipo_Suscripcion_estado]    Script Date: 08/03/2015 23:18:59 ******/
ALTER TABLE [BEST].[G_C_Tipo_Suscripcion] ADD  CONSTRAINT [DF_G_C_Tipo_Suscripcion_estado]  DEFAULT ('A') FOR [estado]
GO
/****** Object:  Default [DF_G_C_Usuario_fecha_registro]    Script Date: 08/03/2015 23:18:59 ******/
ALTER TABLE [BEST].[G_C_Usuario] ADD  CONSTRAINT [DF_G_C_Usuario_fecha_registro]  DEFAULT (getdate()) FOR [fecha_registro]
GO
/****** Object:  Default [DF_G_C_Usuario_estado]    Script Date: 08/03/2015 23:18:59 ******/
ALTER TABLE [BEST].[G_C_Usuario] ADD  CONSTRAINT [DF_G_C_Usuario_estado]  DEFAULT ('A') FOR [estado]
GO
/****** Object:  Default [DF_G_D_Empresa_Modulo_fecha_registro]    Script Date: 08/03/2015 23:18:59 ******/
ALTER TABLE [BEST].[G_D_Empresa_Modulo] ADD  CONSTRAINT [DF_G_D_Empresa_Modulo_fecha_registro]  DEFAULT (getdate()) FOR [fecha_registro]
GO
/****** Object:  Default [DF_G_D_Empresa_Modulo_estado]    Script Date: 08/03/2015 23:18:59 ******/
ALTER TABLE [BEST].[G_D_Empresa_Modulo] ADD  CONSTRAINT [DF_G_D_Empresa_Modulo_estado]  DEFAULT ('A') FOR [estado]
GO
/****** Object:  Default [DF_G_D_Empresa_Roles_fecha_registro]    Script Date: 08/03/2015 23:18:59 ******/
ALTER TABLE [BEST].[G_D_Empresa_Roles] ADD  CONSTRAINT [DF_G_D_Empresa_Roles_fecha_registro]  DEFAULT (getdate()) FOR [fecha_registro]
GO
/****** Object:  Default [DF_G_D_Empresa_Roles_estado]    Script Date: 08/03/2015 23:18:59 ******/
ALTER TABLE [BEST].[G_D_Empresa_Roles] ADD  CONSTRAINT [DF_G_D_Empresa_Roles_estado]  DEFAULT ('A') FOR [estado]
GO
/****** Object:  Default [DF_G_D_Suscripcion_fecha_registro]    Script Date: 08/03/2015 23:18:59 ******/
ALTER TABLE [BEST].[G_D_Suscripcion] ADD  CONSTRAINT [DF_G_D_Suscripcion_fecha_registro]  DEFAULT (getdate()) FOR [fecha_registro]
GO
/****** Object:  Default [DF_G_D_Suscripcion_estado]    Script Date: 08/03/2015 23:18:59 ******/
ALTER TABLE [BEST].[G_D_Suscripcion] ADD  CONSTRAINT [DF_G_D_Suscripcion_estado]  DEFAULT ('A') FOR [estado]
GO
/****** Object:  Default [DF_G_D_Usuario_Cambio_Password_fecha_cambio]    Script Date: 08/03/2015 23:18:59 ******/
ALTER TABLE [BEST].[G_D_Usuario_Password] ADD  CONSTRAINT [DF_G_D_Usuario_Cambio_Password_fecha_cambio]  DEFAULT (getdate()) FOR [fecha_registro]
GO
/****** Object:  Default [DF_G_D_Usuario_Password_estado]    Script Date: 08/03/2015 23:18:59 ******/
ALTER TABLE [BEST].[G_D_Usuario_Password] ADD  CONSTRAINT [DF_G_D_Usuario_Password_estado]  DEFAULT ('A') FOR [estado]
GO
/****** Object:  ForeignKey [FK_G_C_Usuario_G_C_Empresa]    Script Date: 08/03/2015 23:18:59 ******/
ALTER TABLE [BEST].[G_C_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_G_C_Usuario_G_C_Empresa] FOREIGN KEY([id_empresa])
REFERENCES [BEST].[G_C_Empresa] ([id_empresa])
GO
ALTER TABLE [BEST].[G_C_Usuario] CHECK CONSTRAINT [FK_G_C_Usuario_G_C_Empresa]
GO
/****** Object:  ForeignKey [FK_G_D_Empresa_Modulo_G_C_Empresa]    Script Date: 08/03/2015 23:18:59 ******/
ALTER TABLE [BEST].[G_D_Empresa_Modulo]  WITH CHECK ADD  CONSTRAINT [FK_G_D_Empresa_Modulo_G_C_Empresa] FOREIGN KEY([id_empresa])
REFERENCES [BEST].[G_C_Empresa] ([id_empresa])
GO
ALTER TABLE [BEST].[G_D_Empresa_Modulo] CHECK CONSTRAINT [FK_G_D_Empresa_Modulo_G_C_Empresa]
GO
/****** Object:  ForeignKey [FK_G_D_Empresa_Modulo_G_C_Modulos]    Script Date: 08/03/2015 23:18:59 ******/
ALTER TABLE [BEST].[G_D_Empresa_Modulo]  WITH CHECK ADD  CONSTRAINT [FK_G_D_Empresa_Modulo_G_C_Modulos] FOREIGN KEY([id_modulo])
REFERENCES [BEST].[G_C_Modulos] ([id_modulo])
GO
ALTER TABLE [BEST].[G_D_Empresa_Modulo] CHECK CONSTRAINT [FK_G_D_Empresa_Modulo_G_C_Modulos]
GO
/****** Object:  ForeignKey [FK_G_D_Empresa_Roles_G_C_Empresa]    Script Date: 08/03/2015 23:18:59 ******/
ALTER TABLE [BEST].[G_D_Empresa_Roles]  WITH CHECK ADD  CONSTRAINT [FK_G_D_Empresa_Roles_G_C_Empresa] FOREIGN KEY([id_empresa])
REFERENCES [BEST].[G_C_Empresa] ([id_empresa])
GO
ALTER TABLE [BEST].[G_D_Empresa_Roles] CHECK CONSTRAINT [FK_G_D_Empresa_Roles_G_C_Empresa]
GO
/****** Object:  ForeignKey [FK_G_D_Empresa_Roles_G_C_Roles]    Script Date: 08/03/2015 23:18:59 ******/
ALTER TABLE [BEST].[G_D_Empresa_Roles]  WITH CHECK ADD  CONSTRAINT [FK_G_D_Empresa_Roles_G_C_Roles] FOREIGN KEY([id_rol])
REFERENCES [BEST].[G_C_Roles] ([id_rol])
GO
ALTER TABLE [BEST].[G_D_Empresa_Roles] CHECK CONSTRAINT [FK_G_D_Empresa_Roles_G_C_Roles]
GO
/****** Object:  ForeignKey [FK_G_D_Suscripcion_G_C_Tipo_Suscripcion]    Script Date: 08/03/2015 23:18:59 ******/
ALTER TABLE [BEST].[G_D_Suscripcion]  WITH CHECK ADD  CONSTRAINT [FK_G_D_Suscripcion_G_C_Tipo_Suscripcion] FOREIGN KEY([id_tipo_suscripcion])
REFERENCES [BEST].[G_C_Tipo_Suscripcion] ([id_tipo_suscripcion])
GO
ALTER TABLE [BEST].[G_D_Suscripcion] CHECK CONSTRAINT [FK_G_D_Suscripcion_G_C_Tipo_Suscripcion]
GO
/****** Object:  ForeignKey [FK_G_D_Suscripcion_G_C_Usuario]    Script Date: 08/03/2015 23:18:59 ******/
ALTER TABLE [BEST].[G_D_Suscripcion]  WITH CHECK ADD  CONSTRAINT [FK_G_D_Suscripcion_G_C_Usuario] FOREIGN KEY([id_empresa], [id_usuario])
REFERENCES [BEST].[G_C_Usuario] ([id_empresa], [id_usuario])
GO
ALTER TABLE [BEST].[G_D_Suscripcion] CHECK CONSTRAINT [FK_G_D_Suscripcion_G_C_Usuario]
GO
/****** Object:  ForeignKey [FK_G_D_Usuario_Acceso_G_C_Usuario]    Script Date: 08/03/2015 23:18:59 ******/
ALTER TABLE [BEST].[G_D_Usuario_Acceso]  WITH CHECK ADD  CONSTRAINT [FK_G_D_Usuario_Acceso_G_C_Usuario] FOREIGN KEY([id_empresa], [id_usuario])
REFERENCES [BEST].[G_C_Usuario] ([id_empresa], [id_usuario])
GO
ALTER TABLE [BEST].[G_D_Usuario_Acceso] CHECK CONSTRAINT [FK_G_D_Usuario_Acceso_G_C_Usuario]
GO
/****** Object:  ForeignKey [FK_G_D_Usuario_Password_G_C_Usuario]    Script Date: 08/03/2015 23:18:59 ******/
ALTER TABLE [BEST].[G_D_Usuario_Password]  WITH CHECK ADD  CONSTRAINT [FK_G_D_Usuario_Password_G_C_Usuario] FOREIGN KEY([id_empresa], [id_usuario])
REFERENCES [BEST].[G_C_Usuario] ([id_empresa], [id_usuario])
GO
ALTER TABLE [BEST].[G_D_Usuario_Password] CHECK CONSTRAINT [FK_G_D_Usuario_Password_G_C_Usuario]
GO
/****** Object:  ForeignKey [FK_G_D_Usuario_Roles_G_C_Roles]    Script Date: 08/03/2015 23:18:59 ******/
ALTER TABLE [BEST].[G_D_Usuario_Roles]  WITH CHECK ADD  CONSTRAINT [FK_G_D_Usuario_Roles_G_C_Roles] FOREIGN KEY([id_rol])
REFERENCES [BEST].[G_C_Roles] ([id_rol])
GO
ALTER TABLE [BEST].[G_D_Usuario_Roles] CHECK CONSTRAINT [FK_G_D_Usuario_Roles_G_C_Roles]
GO
/****** Object:  ForeignKey [FK_G_D_Usuario_Roles_G_C_Usuario]    Script Date: 08/03/2015 23:18:59 ******/
ALTER TABLE [BEST].[G_D_Usuario_Roles]  WITH CHECK ADD  CONSTRAINT [FK_G_D_Usuario_Roles_G_C_Usuario] FOREIGN KEY([id_empresa], [id_usuario])
REFERENCES [BEST].[G_C_Usuario] ([id_empresa], [id_usuario])
GO
ALTER TABLE [BEST].[G_D_Usuario_Roles] CHECK CONSTRAINT [FK_G_D_Usuario_Roles_G_C_Usuario]
GO
