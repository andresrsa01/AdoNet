USE [Trabajador]
GO
/****** Object:  StoredProcedure [dbo].[BorrarPersonal]    Script Date: 19/07/2016 03:59:48 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[BorrarPersonal]
 @ID int
 as
 delete from Empleado where ID = @ID
GO
/****** Object:  StoredProcedure [dbo].[ListarTodoPersonal]    Script Date: 19/07/2016 03:59:48 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[ListarTodoPersonal]
 as
 select * from Empleado
GO
/****** Object:  StoredProcedure [dbo].[ModificarPeronal]    Script Date: 19/07/2016 03:59:48 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ModificarPeronal]
@ID int,
@Nombre nvarchar(50),
@ApePaterno nvarchar(50),
@ApeMaterno nvarchar(50),
@Pais nvarchar(50),
@Fecha date,
@Salario decimal(18,2),
@IDCategoria int
as
Update Empleado set Nombre = @Nombre, ApePaterno = @ApePaterno, ApeMaterno = @ApeMaterno,
 Pais = @Pais, Fecha = @Fecha, Salario = @Salario where ID = @ID
GO
/****** Object:  StoredProcedure [dbo].[RegistrarPeronal]    Script Date: 19/07/2016 03:59:48 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RegistrarPeronal]
@Nombre nvarchar(50),
@ApePaterno nvarchar(50),
@ApeMaterno nvarchar(50),
@Pais nvarchar(50),
@Fecha date,
@Salario decimal(18,2),
@IDCategoria int
as
insert into Empleado(Nombre,ApePaterno,ApeMaterno,Pais,Fecha,Salario, IDCategoria) values
(@Nombre,@ApePaterno,@ApeMaterno,@Pais,@Fecha,@Salario,@IDCategoria)
GO
