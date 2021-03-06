USE [master]
GO
/****** Object:  Database [Bdd_Ctgi]    Script Date: 02/07/2017 10:43:49 p. m. ******/
CREATE DATABASE [Bdd_Ctgi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Bdd_Ctgi', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Bdd_Ctgi.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Bdd_Ctgi_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Bdd_Ctgi_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Bdd_Ctgi] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Bdd_Ctgi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Bdd_Ctgi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Bdd_Ctgi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Bdd_Ctgi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Bdd_Ctgi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Bdd_Ctgi] SET ARITHABORT OFF 
GO
ALTER DATABASE [Bdd_Ctgi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Bdd_Ctgi] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Bdd_Ctgi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Bdd_Ctgi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Bdd_Ctgi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Bdd_Ctgi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Bdd_Ctgi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Bdd_Ctgi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Bdd_Ctgi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Bdd_Ctgi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Bdd_Ctgi] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Bdd_Ctgi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Bdd_Ctgi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Bdd_Ctgi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Bdd_Ctgi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Bdd_Ctgi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Bdd_Ctgi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Bdd_Ctgi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Bdd_Ctgi] SET RECOVERY FULL 
GO
ALTER DATABASE [Bdd_Ctgi] SET  MULTI_USER 
GO
ALTER DATABASE [Bdd_Ctgi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Bdd_Ctgi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Bdd_Ctgi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Bdd_Ctgi] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Bdd_Ctgi]
GO
/****** Object:  StoredProcedure [dbo].[GestionCompetencias]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GestionCompetencias] (
 
    @action varchar(6),
	@id_comp int =NULL,
	@codigo_comp varchar(50)=NULL, 
	@nombre_comp varchar (50)=NULL,
	@descripcion_comp varchar(50)=NULL,
	@id_programa int=null
)
As Begin
If @action='insert'
Begin
INSERT INTO competencia
          (codigo_comp
		  ,nombre_comp
          ,descripcion_comp
		  )
    VALUES
          (	@codigo_comp
		  ,@nombre_comp
		,@descripcion_comp
	 )

INSERT INTO competencia_programa VALUES (@@IDENTITY, @id_programa)
End
Else If @action='update'
Begin
UPDATE competencia
  SET nombre_comp = @nombre_comp,
      descripcion_comp = @descripcion_comp
WHERE codigo_comp = @codigo_comp
Select @id_comp=id_comp  from competencia Where codigo_comp = @codigo_comp
UPDATE competencia_programa
  SET id_programa = @id_programa
WHERE id_competencia = @id_comp
End
  
Else If @action='delete'
Begin
Select @id_comp=id_comp  from competencia Where codigo_comp = @codigo_comp
DELETE FROM competencia_programa WHERE id_competencia=@id_comp AND id_programa=@id_programa
DELETE FROM competencia WHERE id_comp=@id_comp

End
Else If @action='list'
Begin
Select codigo_comp,nombre_comp,descripcion_comp,nombre_prog,id_prog from competencia COM INNER JOIN competencia_programa ON id_competencia=com.id_comp
INNER JOIN programa ON id_programa=id_prog
End

Else If @action='Search'
Begin
Select * from competencia Where codigo_comp = @codigo_comp
End
End









GO
/****** Object:  StoredProcedure [dbo].[prc_GestionLinea]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[prc_GestionLinea] (

@action VARCHAR(6),
	@id_linea int=NULL,
	@nombre_linea varchar(50)=NULL,
	@descripcion_linea varchar(300)=NULL

) AS BEGIN 
IF @action='Insert'
	BEGIN
		INSERT INTO linea_tec (  nombre_linea , descripcion_linea)
				VALUES (  @nombre_linea, @descripcion_linea)
	END 
ELSE IF @action='Update'
	BEGIN
		UPDATE linea_tec
		SET  nombre_linea=@nombre_linea, descripcion_linea=@descripcion_linea
		WHERE id_linea=@id_linea
	END 
ELSE IF @action='Delete'
	BEGIN
		DELETE FROM linea_tec WHERE id_linea = @id_linea
	END 
ELSE IF @action='Select'
	BEGIN 
		SELECT  id_linea, nombre_linea, descripcion_linea  FROM linea_tec
	END
	ELSE IF @action='Select2'
	BEGIN 
		SELECT  id_linea, nombre_linea, descripcion_linea FROM linea_tec WHERE id_linea = @id_linea
	END
END










GO
/****** Object:  StoredProcedure [dbo].[prc_GestionPrograma]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[prc_GestionPrograma]
(
	@action varchar(10),
	@id_prog int = null,
	@codigo_prog varchar(50) = null,
	@nombre_prog varchar(150) = null,
	@descripcion_prog text = null,
	@version_prog varchar(20) = null,
	@id_linea int = null
	)
	As begin
	if @action='insert'
		begin
			INSERT INTO programa ( codigo_prog, nombre_prog, descripcion_prog, version_prog )
			VALUES ( @codigo_prog, @nombre_prog, @descripcion_prog, @version_prog);

			INSERT INTO lineaTecno_programa (id_linea_tecno, id_prog)
			VALUES ( @id_linea, @@IDENTITY )
		end
	else if @action='update'
		begin
		select @id_prog=id_prog from programa where codigo_prog = @codigo_prog;
			UPDATE programa
			SET nombre_prog = @nombre_prog, descripcion_prog = @descripcion_prog, version_prog = @version_prog
			WHERE codigo_prog = @codigo_prog;

			UPDATE lineaTecno_programa 
			SET id_linea_tecno = @id_linea where id_prog=@id_prog
		end
	else if @action='delete'
		begin
			select @id_prog=id_prog from programa where codigo_prog = @codigo_prog;
			DELETE FROM lineaTecno_programa WHERE id_prog=@id_prog;
			DELETE FROM programa WHERE codigo_prog = @codigo_prog;
		end
	else if @action='list'
		begin
			select codigo_prog, nombre_prog, descripcion_prog, version_prog, lineaTecno_programa.id_linea_tecno,linea_tecno.nombre_linea_tecno from programa INNER JOIN lineaTecno_programa on programa.id_prog = lineaTecno_programa.id_prog
			INNER JOIN linea_tecno ON linea_tecno.id_linea_tecno=lineaTecno_programa.id_linea_tecno;
		end
	else if @action='search'
		begin
			select codigo_prog, nombre_prog, descripcion_prog, version_prog, id_linea_tecno from programa INNER JOIN lineaTecno_programa on programa.id_prog = lineaTecno_programa.id_prog;
		end 
	end



GO
/****** Object:  StoredProcedure [dbo].[prcGestionAmbiente]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[prcGestionAmbiente](
@action VARCHAR(7), 
@codigo_amb int =0,
@nombre_amb VARCHAR(50) = null,
@capacidad_amb VARCHAR(50) = null,
@estado_amb VARCHAR(50) = null
)
as begin
if @action='insert'
begin 
insert into ambiente(codigo_amb,nombre_amb,capacidad_amb,estado_amb)
values (@codigo_amb,@nombre_amb,@capacidad_amb,@estado_amb)
end
else if @action='search'
begin
select * from ambiente where codigo_amb=@codigo_amb
end
else if @action='update'
begin 
update ambiente
set nombre_amb=@nombre_amb,capacidad_amb=@capacidad_amb,estado_amb=@estado_amb
where codigo_amb=@codigo_amb
end
else if @action='delete'
begin
delete from ambiente where codigo_amb=@codigo_amb
end
else if @action='select'
begin
select codigo_amb,nombre_amb,capacidad_amb,estado_amb FROM ambiente
end
end











GO
/****** Object:  StoredProcedure [dbo].[prcGestionCohorte]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[prcGestionCohorte](
@action varchar(6),
@codigo_cohorte bigint=0,
@nombre_cohorte varchar(100)=null,
@fecha_inicio_cohorte date=null,
@fecha_fin_cohorte date=null,
@año_cohorte varchar(10)=null,
@trimestre_cohorte int=0
)
as begin
	If @action='insert'
	Begin 
	Insert into cohorte(codigo_coho,nombre_coho,fechainicio_coho,fechafin_coho,año_coho,trimestre_coho)
	Values (@codigo_cohorte,@nombre_cohorte,@fecha_inicio_cohorte,@fecha_fin_cohorte,@año_cohorte,@trimestre_cohorte)
	END
	Else if @action='update'
	Begin
	Update cohorte
	SET nombre_coho=@nombre_cohorte,fechainicio_coho=@fecha_inicio_cohorte,
	fechafin_coho=@fecha_fin_cohorte,año_coho=@año_cohorte,trimestre_coho=@trimestre_cohorte
	WHERE codigo_coho=@codigo_cohorte
	END
	Else if @action='delete'
	Begin
	delete from cohorte WHERE codigo_coho=@codigo_cohorte
	END
	Else if @action='select'
	Begin
	select codigo_coho,nombre_coho,fechainicio_coho,fechafin_coho,año_coho,trimestre_coho FROM cohorte
	END
	Else if @action='search'
	Begin
		select * from cohorte where codigo_coho=@codigo_cohorte
	END
END











GO
/****** Object:  StoredProcedure [dbo].[prcGestionFicha]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[prcGestionFicha](
@action varchar(6),
@codigo_ficha bigint=0,
@nombre_ficha int=0,
@nintegrantes_ficha int=null,
@jornada_ficha varchar(100)=null,
@id_cohorte int=0,
@nom_prog nchar(60)=null,
@id_programa int=0,
@id_ficha int=0
)
as begin
	If @action='insert'
	Begin 
	Insert into ficha(codigo_ficha,nintegrantes_ficha,jornada_ficha)
	Values (@codigo_ficha,@nintegrantes_ficha,@jornada_ficha)
	select @id_ficha=@@IDENTITY from ficha
	Insert into ficha_cohorte(id_ficha,id_cohorte)
	Values (@@IDENTITY,@id_cohorte)
	insert into ficha_programa values (@id_ficha,@id_programa)
	END
	Else if @action='update'
	Begin
	select @id_ficha=id_ficha from ficha where codigo_ficha=@codigo_ficha
	Update ficha
	SET nintegrantes_ficha=@nintegrantes_ficha,jornada_ficha=@jornada_ficha
	WHERE codigo_ficha=@codigo_ficha
	Update ficha_cohorte
	SET id_cohorte=@id_cohorte
	WHERE id_ficha=@id_ficha
	Update ficha_programa
	SET id_programa=@id_programa
	WHERE id_ficha=@id_ficha
	END
	Else if @action='delete'
	Begin
	select @id_ficha=id_ficha from ficha where codigo_ficha=@codigo_ficha
	delete from ficha_programa where id_ficha=@id_ficha
	delete from ficha_cohorte WHERE id_ficha=@id_ficha
	delete from ficha WHERE id_ficha=@id_ficha
	END
	Else if @action='select'
	Begin
		select codigo_ficha,nintegrantes_ficha,jornada_ficha,ficha_programa.id_programa,id_cohorte from ficha FI 
		INNER JOIN ficha_cohorte on FI.id_ficha = ficha_cohorte.id_ficha
		INNER JOIN ficha_programa on FI.id_ficha =ficha_programa.id_ficha WHERE codigo_ficha=@codigo_ficha
		END
	Else if @action='search'
	Begin
		select codigo_ficha,nintegrantes_ficha,jornada_ficha,nombre_coho,nombre_prog,ficha_programa.id_programa AS id_program,id_cohorte from ficha FI INNER JOIN ficha_cohorte on FI.id_ficha = ficha_cohorte.id_ficha 
		INNER JOIN cohorte on cohorte.id_coho =ficha_cohorte.id_cohorte
		INNER JOIN ficha_programa on FI.id_ficha =ficha_programa.id_ficha
		INNER JOIN programa on ficha_programa.id_programa= programa.id_prog
	END
END











GO
/****** Object:  StoredProcedure [dbo].[prcGestionInstructores]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[prcGestionInstructores](
@action varchar(6),
@dni_instructor nchar(20)=null,
@nombre_instructor text=null,
@apellido_instructor text=null,
@profesion text=null
)
as begin
	If @action='insert'
	Begin 
	Insert into tbl_instructor(dni_instructor,nombre_instructor,apellido_instructor,profesion)
	Values (@dni_instructor,@nombre_instructor,@apellido_instructor,@profesion)
	END
	Else if @action='update'
	Begin
	Update tbl_instructor
	SET nombre_instructor=@nombre_instructor,apellido_instructor=@apellido_instructor,
	profesion=@profesion WHERE dni_instructor=@dni_instructor
	END
	Else if @action='delete'
	Begin
	delete from tbl_instructor WHERE dni_instructor=@dni_instructor
	END
	Else if @action='select'
	Begin
	select dni_instructor,nombre_instructor,apellido_instructor,profesion FROM tbl_instructor
	END
	Else if @action='search'
	Begin
		select * from tbl_instructor where dni_instructor=@dni_instructor
	END
END





GO
/****** Object:  StoredProcedure [dbo].[prcGestionLinea_tecno]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[prcGestionLinea_tecno](
@action VARCHAR(7), 
@nombre_linea_tecno VARCHAR(250) = null
)
as begin
if @action='insert'
begin 
insert into linea_tecno(nombre_linea_tecno)
values (@nombre_linea_tecno)
end
else if @action='search'
begin
select * from linea_tecno where nombre_linea_tecno LIKE '%'+@nombre_linea_tecno+'%';
end
else if @action='select'
begin
select * FROM linea_tecno
end
end





GO
/****** Object:  StoredProcedure [dbo].[prcGestionTemas]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[prcGestionTemas](
@action VARCHAR(7), 
@id_tema int=null,
@codigo_tema NCHAR(10) = null,
@nombre_tema VARCHAR(50) = null,
@descripcion_tema NTEXT = null,
@id_resul int =null
)
as begin
if @action='insert'
begin 
insert into tbl_tema(codigo_tema,nombre_tema,descripcion_tema)
values (@codigo_tema,@nombre_tema,@descripcion_tema)
insert into tema_resultado values (@@IDENTITY,@id_resul)
end
else if @action='search'
begin
select * from tbl_tema  INNER JOIN tema_resultado on tbl_tema.id_tema=tema_resultado.id_tema where codigo_tema=@codigo_tema
end
else if @action='update'
begin 
select @id_tema=id_tema from tbl_tema where codigo_tema=@codigo_tema 
update tbl_tema
set nombre_tema = @nombre_tema,descripcion_tema = @descripcion_tema
where codigo_tema=@codigo_tema 
update tema_resultado set id_resultado=@id_resul where id_tema=@id_tema
end
else if @action='delete'
begin
select @id_tema=id_tema from tbl_tema where codigo_tema=@codigo_tema 
delete from tema_resultado where id_tema=@id_tema
delete from tbl_tema where @codigo_tema=codigo_tema 
end
else if @action='select'
begin
select codigo_tema,nombre_tema,descripcion_tema, nombre_resu, id_resultado FROM tbl_tema TEM iNNER JOIN tema_resultado
on tema_resultado.id_tema=TEM.id_tema INNER JOIN resultado on id_resu=id_resultado
end
end







GO
/****** Object:  StoredProcedure [dbo].[prcHorarioInstructores]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[prcHorarioInstructores] 
as 
Select  fechainicio_asig,fechafin_asig,
horainicio_asig,horafin_asig,dia_asig,nombre_amb,codigo_ficha,CONCAT(nombre_instructor,' ',apellido_instructor) AS nombre_instructor,nombre_resu from asignacion ASI 
  INNER JOIN Crystal ON id_asig = id_asignacion
  INNER JOIN ambiente ON id_amb=id_ambiente  
  INNER JOIN ficha ON ficha.id_ficha=Crystal.id_ficha
  INNER JOIN tbl_instructor ON Crystal.id_instructor=tbl_instructor.id_instructor
  INNER JOIN resultado ON resultado.id_resu= Crystal.id_resultado


GO
/****** Object:  StoredProcedure [dbo].[ProcedureAsignaciones]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProcedureAsignaciones] (
    @action varchar(20)=null,
	@id_asig int =null,
	@codigo_asig varchar(50)=NULL,
	@fecha_ini Date=NULL,
	@fecha_fin Date=NULL,
	@hora_ini time(7)=NULL,
	@hora_fin time(7)=NULL,
	@dia_asig varchar(10)=NULL,
	@descripcion_asig varchar(254)=NULL,
	@id_amb int=NULL,
	@id_ficha int=NULL,
	@id_resul int=NULL,
	@id_instru int=NULL
)
As Begin
If @action='insert'
Begin
INSERT INTO asignacion
          (cod_asig
          ,fechainicio_asig
          ,fechafin_asig
		  ,horainicio_asig
		  ,horafin_asig
		  ,dia_asig,
		  descripcion_asig
		  )
    VALUES
          (@codigo_asig
          ,@fecha_ini
          ,@fecha_fin
		  ,@hora_ini
		  ,@hora_fin
		  ,@dia_asig,
		  @descripcion_asig
		  )

select @id_asig=@@IDENTITY from asignacion
INSERT into asignacion_ambiente VALUES (@id_asig,@id_amb)
INSERT into asignacion_ficha VALUES (@id_asig,@id_ficha)
INSERT into asignacion_resultado VALUES (@id_asig,@id_resul)
INSERT into instructor_asignacion VALUES (@id_asig,@id_instru)
INSERT INTO Crystal
		(id_asignacion,
		id_ambiente,
		id_ficha,
		id_resultado,
		id_instructor)
	VALUES
		(
		@id_asig,
		@id_amb,
		@id_ficha,
		@id_resul,
		@id_instru		
		)
End
Else If @action='update'
Begin
SELECT @id_asig=@id_asig FROM asignacion WHERE @codigo_asig = @codigo_asig

UPDATE asignacion
  SET 
     fechainicio_asig = @fecha_ini,
     fechafin_asig = @fecha_fin,
     horainicio_asig = @hora_ini,
	 horafin_asig = @hora_fin,
	 dia_asig = @dia_asig,
	 descripcion_asig=@descripcion_asig
WHERE cod_asig = @codigo_asig
UPDATE asignacion_ambiente SET id_ambiente= @id_amb WHERE id_asignacion=@id_asig
UPDATE asignacion_ficha SET id_ficha= @id_ficha WHERE id_asignacion=@id_asig
UPDATE asignacion_resultado SET id_resultado= @id_resul WHERE id_asignacion=@id_asig
UPDATE instructor_asignacion SET id_instructor= @id_instru WHERE id_asignacion=@id_asig
End
  
Else If @action='delete'
Begin
SELECT @id_asig=id_asig FROM asignacion WHERE cod_asig = @codigo_asig
DELETE FROM asignacion_ambiente WHERE id_asignacion=@id_asig
DELETE FROM asignacion_ficha WHERE id_asignacion=@id_asig
DELETE FROM asignacion_resultado WHERE id_asignacion=@id_asig
DELETE FROM instructor_asignacion  WHERE id_asignacion=@id_asig
DELETE FROM asignacion WHERE id_asig=@id_asig
End
Else If @action='list'

Begin
Select cod_asig,fechainicio_asig,fechafin_asig, 
horainicio_asig,horafin_asig,dia_asig,descripcion_asig,nombre_amb,codigo_ficha,CONCAT(nombre_instructor,' ',apellido_instructor) AS nombre_instructor,nombre_resu from asignacion ASI INNER JOIN asignacion_ambiente ON ASI.id_asig=id_asignacion
 INNER JOIN ambiente ON id_amb=id_ambiente INNER JOIN asignacion_ficha ON asignacion_ficha.id_asignacion=ASI.id_asig INNER JOIN ficha ON ficha.id_ficha=asignacion_ficha.id_ficha
 INNER JOIN instructor_asignacion ON ASI.id_asig=instructor_asignacion.id_asignacion INNER JOIN tbl_instructor ON instructor_asignacion.id_instructor=tbl_instructor.id_instructor
 INNER JOIN asignacion_resultado ON ASI.id_asig=asignacion_resultado.id_asignacion INNER JOIN resultado ON resultado.id_resu=asignacion_resultado.id_resultado
End
Else If @action='Search'
Begin

SELECT @id_asig=id_asig FROM asignacion WHERE cod_asig = @codigo_asig
Select cod_asig,fechainicio_asig,fechafin_asig, 
horainicio_asig,horafin_asig,dia_asig,descripcion_asig,id_ambiente,id_ficha,id_instructor,id_resultado from asignacion ASI INNER JOIN asignacion_ambiente ON ASI.id_asig=id_asignacion
 INNER JOIN asignacion_ficha ON asignacion_ficha.id_asignacion=ASI.id_asig
 INNER JOIN instructor_asignacion ON ASI.id_asig=instructor_asignacion.id_asignacion
 INNER JOIN asignacion_resultado ON ASI.id_asig=asignacion_resultado.id_asignacion WHERE ASI.id_asig=@id_asig
End

Else If @action='disponibilidad'
Begin
Select cod_asig,fechainicio_asig,fechafin_asig, 
horainicio_asig,horafin_asig,dia_asig,descripcion_asig,nombre_amb,codigo_ficha,CONCAT(nombre_instructor,' ',apellido_instructor) AS nombre_instructor,nombre_resu,id_ambiente,ficha.id_ficha,tbl_instructor.id_instructor from asignacion ASI INNER JOIN asignacion_ambiente ON ASI.id_asig=id_asignacion
 INNER JOIN ambiente ON id_amb=id_ambiente INNER JOIN asignacion_ficha ON asignacion_ficha.id_asignacion=ASI.id_asig INNER JOIN ficha ON ficha.id_ficha=asignacion_ficha.id_ficha
 INNER JOIN instructor_asignacion ON ASI.id_asig=instructor_asignacion.id_asignacion INNER JOIN tbl_instructor ON instructor_asignacion.id_instructor=tbl_instructor.id_instructor
 INNER JOIN asignacion_resultado ON ASI.id_asig=asignacion_resultado.id_asignacion INNER JOIN resultado ON resultado.id_resu=asignacion_resultado.id_resultado
 WHERE @fecha_ini<=fechafin_asig and dia_asig=@dia_asig and @hora_ini<=horafin_asig 
 AND (id_ambiente=@id_amb or asignacion_ficha.id_ficha=@id_ficha or instructor_asignacion.id_instructor=@id_instru)
End
Else If @action='horasinstu'
Begin
Select Sum(DATEDIFF( MI , horainicio_asig , horafin_asig)) AS minutos from asignacion ASI
INNER JOIN instructor_asignacion ON ASI.id_asig=instructor_asignacion.id_asignacion
WHERE  instructor_asignacion.id_instructor=@id_instru
END
End 


GO
/****** Object:  StoredProcedure [dbo].[ProcedureResultado]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProcedureResultado] (

    @action varchar(20)=null,
	@id_resu int =null,
	@codigo_resu varchar(50)=NULL,
	@nombre_resu varchar(150)=NULL,
	/*@horainicio_resu time(7)=NULL,
	@horafin_resu time(7)=NULL,*/
	@descripcion_resu varchar(230)=NULL,
	@id_competencia int=NULL
)
As Begin
If @action='insert'
Begin
INSERT INTO resultado
          (codigo_resu
          ,nombre_resu
		  ,descripcion_resu
		  )
    VALUES
          (@codigo_resu
          ,@nombre_resu
		  ,@descripcion_resu
		  )
INSERT into competencia_resultado VALUES (@@IDENTITY,@id_competencia)
End
Else If @action='update'
Begin
SELECT @id_resu=id_resu FROM resultado WHERE codigo_resu = @codigo_resu

UPDATE resultado
  SET 
     nombre_resu = @nombre_resu,
	 descripcion_resu=@descripcion_resu
    
WHERE codigo_resu = @codigo_resu
UPDATE competencia_resultado SET id_competencia= @id_competencia WHERE id_resultado=@id_resu

End
  
Else If @action='delete'
Begin
SELECT @id_resu=id_resu FROM resultado WHERE codigo_resu = @codigo_resu
DELETE FROM competencia_resultado WHERE id_resultado=@id_resu
DELETE FROM resultado WHERE  codigo_resu = @codigo_resu
End
Else If @action='list'
Begin
Select codigo_resu,nombre_resu,
descripcion_resu,nombre_comp,id_competencia from resultado RE 
INNER JOIN competencia_resultado ON RE.id_resu = competencia_resultado.id_resultado INNER JOIN 
competencia ON competencia_resultado.id_competencia= competencia.id_comp
End
Else If @action='Search'
Begin
SELECT @id_resu=id_resu FROM resultado WHERE codigo_resu = @codigo_resu
Select *,id_competencia as id_comp from resultado,competencia_resultado Where id_resu = @id_resu
End
End










GO
/****** Object:  Table [dbo].[ambiente]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ambiente](
	[id_amb] [int] IDENTITY(1,1) NOT NULL,
	[codigo_amb] [varchar](50) NOT NULL,
	[nombre_amb] [varchar](150) NOT NULL,
	[capacidad_amb] [int] NOT NULL,
	[estado_amb] [varchar](30) NOT NULL,
 CONSTRAINT [PK_ambiente] PRIMARY KEY CLUSTERED 
(
	[id_amb] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_ambiente] UNIQUE NONCLUSTERED 
(
	[codigo_amb] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[asignacion]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[asignacion](
	[id_asig] [int] IDENTITY(1,1) NOT NULL,
	[cod_asig] [varchar](50) NOT NULL,
	[fechainicio_asig] [date] NOT NULL,
	[fechafin_asig] [date] NOT NULL,
	[horainicio_asig] [time](7) NOT NULL,
	[horafin_asig] [time](7) NOT NULL,
	[dia_asig] [varchar](11) NOT NULL,
	[descripcion_asig] [text] NOT NULL,
 CONSTRAINT [PK_asignacion] PRIMARY KEY CLUSTERED 
(
	[id_asig] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_asignacion_1] UNIQUE NONCLUSTERED 
(
	[cod_asig] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[asignacion_ambiente]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[asignacion_ambiente](
	[id_asignacion] [int] NOT NULL,
	[id_ambiente] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[asignacion_ficha]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[asignacion_ficha](
	[id_asignacion] [int] NOT NULL,
	[id_ficha] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[asignacion_resultado]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[asignacion_resultado](
	[id_asignacion] [int] NOT NULL,
	[id_resultado] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[cohorte]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cohorte](
	[id_coho] [int] IDENTITY(1,1) NOT NULL,
	[codigo_coho] [varchar](50) NOT NULL,
	[nombre_coho] [varchar](150) NOT NULL,
	[fechainicio_coho] [date] NOT NULL,
	[fechafin_coho] [date] NOT NULL,
	[año_coho] [varchar](5) NOT NULL,
	[trimestre_coho] [int] NOT NULL,
 CONSTRAINT [PK_cohorte] PRIMARY KEY CLUSTERED 
(
	[id_coho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_cohorte] UNIQUE NONCLUSTERED 
(
	[codigo_coho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[competencia]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[competencia](
	[id_comp] [int] IDENTITY(1,1) NOT NULL,
	[codigo_comp] [varchar](50) NOT NULL,
	[nombre_comp] [varchar](150) NOT NULL,
	[descripcion_comp] [varchar](200) NULL,
 CONSTRAINT [PK_competencia] PRIMARY KEY CLUSTERED 
(
	[id_comp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_competencia] UNIQUE NONCLUSTERED 
(
	[codigo_comp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[competencia_programa]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[competencia_programa](
	[id_competencia] [int] NOT NULL,
	[id_programa] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[competencia_resultado]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[competencia_resultado](
	[id_resultado] [int] NOT NULL,
	[id_competencia] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Crystal]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Crystal](
	[id_asignacion] [int] NOT NULL,
	[id_ambiente] [int] NOT NULL,
	[id_ficha] [int] NOT NULL,
	[id_resultado] [int] NOT NULL,
	[id_instructor] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ficha]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ficha](
	[id_ficha] [int] IDENTITY(1,1) NOT NULL,
	[codigo_ficha] [varchar](50) NOT NULL,
	[nintegrantes_ficha] [int] NOT NULL,
	[jornada_ficha] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ficha] PRIMARY KEY CLUSTERED 
(
	[id_ficha] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_ficha] UNIQUE NONCLUSTERED 
(
	[codigo_ficha] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ficha_cohorte]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ficha_cohorte](
	[id_ficha] [int] NOT NULL,
	[id_cohorte] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ficha_programa]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ficha_programa](
	[id_ficha] [int] NOT NULL,
	[id_programa] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[instructor_asignacion]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[instructor_asignacion](
	[id_asignacion] [int] NOT NULL,
	[id_instructor] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[instructor_programa]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[instructor_programa](
	[id_intructor] [int] NOT NULL,
	[id_prog] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[linea_tecno]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[linea_tecno](
	[id_linea_tecno] [int] IDENTITY(1,1) NOT NULL,
	[nombre_linea_tecno] [varchar](250) NOT NULL,
 CONSTRAINT [PK_linea_tecno] PRIMARY KEY CLUSTERED 
(
	[id_linea_tecno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[lineaTecno_programa]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lineaTecno_programa](
	[id_linea_tecno] [int] NOT NULL,
	[id_prog] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[programa]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[programa](
	[id_prog] [int] IDENTITY(1,1) NOT NULL,
	[codigo_prog] [varchar](50) NOT NULL,
	[nombre_prog] [varchar](150) NOT NULL,
	[version_prog] [varchar](50) NOT NULL,
	[descripcion_prog] [varchar](244) NOT NULL,
 CONSTRAINT [PK_programa] PRIMARY KEY CLUSTERED 
(
	[id_prog] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_programa] UNIQUE NONCLUSTERED 
(
	[codigo_prog] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[programa_ambiente]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[programa_ambiente](
	[id_prog] [int] NOT NULL,
	[id_amb] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[resultado]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[resultado](
	[id_resu] [int] IDENTITY(1,1) NOT NULL,
	[codigo_resu] [varchar](50) NOT NULL,
	[nombre_resu] [varchar](150) NOT NULL,
	[descripcion_resu] [varchar](230) NOT NULL,
 CONSTRAINT [PK_resultado] PRIMARY KEY CLUSTERED 
(
	[id_resu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_resultado] UNIQUE NONCLUSTERED 
(
	[codigo_resu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_instructor]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_instructor](
	[id_instructor] [int] IDENTITY(1,1) NOT NULL,
	[dni_instructor] [nchar](20) NOT NULL,
	[nombre_instructor] [text] NOT NULL,
	[apellido_instructor] [text] NOT NULL,
	[profesion] [text] NOT NULL,
 CONSTRAINT [PK_tbl_instructor] PRIMARY KEY CLUSTERED 
(
	[id_instructor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_tbl_instructor] UNIQUE NONCLUSTERED 
(
	[dni_instructor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_tema]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_tema](
	[id_tema] [int] IDENTITY(1,1) NOT NULL,
	[codigo_tema] [nchar](10) NOT NULL,
	[nombre_tema] [ntext] NOT NULL,
	[descripcion_tema] [ntext] NOT NULL,
 CONSTRAINT [PK_tbl_tema] PRIMARY KEY CLUSTERED 
(
	[id_tema] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_tbl_tema] UNIQUE NONCLUSTERED 
(
	[codigo_tema] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tema_resultado]    Script Date: 02/07/2017 10:43:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tema_resultado](
	[id_tema] [int] NOT NULL,
	[id_resultado] [int] NOT NULL
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[asignacion_ambiente]  WITH CHECK ADD  CONSTRAINT [FK_asignacion_ambiente_ambiente] FOREIGN KEY([id_ambiente])
REFERENCES [dbo].[ambiente] ([id_amb])
GO
ALTER TABLE [dbo].[asignacion_ambiente] CHECK CONSTRAINT [FK_asignacion_ambiente_ambiente]
GO
ALTER TABLE [dbo].[asignacion_ambiente]  WITH CHECK ADD  CONSTRAINT [FK_asignacion_ambiente_asignacion] FOREIGN KEY([id_asignacion])
REFERENCES [dbo].[asignacion] ([id_asig])
GO
ALTER TABLE [dbo].[asignacion_ambiente] CHECK CONSTRAINT [FK_asignacion_ambiente_asignacion]
GO
ALTER TABLE [dbo].[asignacion_ficha]  WITH CHECK ADD  CONSTRAINT [FK_asignacion_ficha_asignacion] FOREIGN KEY([id_asignacion])
REFERENCES [dbo].[asignacion] ([id_asig])
GO
ALTER TABLE [dbo].[asignacion_ficha] CHECK CONSTRAINT [FK_asignacion_ficha_asignacion]
GO
ALTER TABLE [dbo].[asignacion_ficha]  WITH CHECK ADD  CONSTRAINT [FK_asignacion_ficha_ficha] FOREIGN KEY([id_ficha])
REFERENCES [dbo].[ficha] ([id_ficha])
GO
ALTER TABLE [dbo].[asignacion_ficha] CHECK CONSTRAINT [FK_asignacion_ficha_ficha]
GO
ALTER TABLE [dbo].[asignacion_resultado]  WITH CHECK ADD  CONSTRAINT [FK_asignacion_resultado_asignacion] FOREIGN KEY([id_asignacion])
REFERENCES [dbo].[asignacion] ([id_asig])
GO
ALTER TABLE [dbo].[asignacion_resultado] CHECK CONSTRAINT [FK_asignacion_resultado_asignacion]
GO
ALTER TABLE [dbo].[asignacion_resultado]  WITH CHECK ADD  CONSTRAINT [FK_asignacion_resultado_resultado] FOREIGN KEY([id_resultado])
REFERENCES [dbo].[resultado] ([id_resu])
GO
ALTER TABLE [dbo].[asignacion_resultado] CHECK CONSTRAINT [FK_asignacion_resultado_resultado]
GO
ALTER TABLE [dbo].[competencia_programa]  WITH CHECK ADD  CONSTRAINT [FK_competencia_programa_competencia] FOREIGN KEY([id_competencia])
REFERENCES [dbo].[competencia] ([id_comp])
GO
ALTER TABLE [dbo].[competencia_programa] CHECK CONSTRAINT [FK_competencia_programa_competencia]
GO
ALTER TABLE [dbo].[competencia_programa]  WITH CHECK ADD  CONSTRAINT [FK_competencia_programa_programa] FOREIGN KEY([id_programa])
REFERENCES [dbo].[programa] ([id_prog])
GO
ALTER TABLE [dbo].[competencia_programa] CHECK CONSTRAINT [FK_competencia_programa_programa]
GO
ALTER TABLE [dbo].[competencia_resultado]  WITH CHECK ADD  CONSTRAINT [FK_competencia_resultado_competencia] FOREIGN KEY([id_competencia])
REFERENCES [dbo].[competencia] ([id_comp])
GO
ALTER TABLE [dbo].[competencia_resultado] CHECK CONSTRAINT [FK_competencia_resultado_competencia]
GO
ALTER TABLE [dbo].[competencia_resultado]  WITH CHECK ADD  CONSTRAINT [FK_competencia_resultado_resultado] FOREIGN KEY([id_resultado])
REFERENCES [dbo].[resultado] ([id_resu])
GO
ALTER TABLE [dbo].[competencia_resultado] CHECK CONSTRAINT [FK_competencia_resultado_resultado]
GO
ALTER TABLE [dbo].[Crystal]  WITH CHECK ADD  CONSTRAINT [FK_cR_ambiente] FOREIGN KEY([id_ambiente])
REFERENCES [dbo].[ambiente] ([id_amb])
GO
ALTER TABLE [dbo].[Crystal] CHECK CONSTRAINT [FK_cR_ambiente]
GO
ALTER TABLE [dbo].[Crystal]  WITH CHECK ADD  CONSTRAINT [FK_cR_asignacion] FOREIGN KEY([id_asignacion])
REFERENCES [dbo].[asignacion] ([id_asig])
GO
ALTER TABLE [dbo].[Crystal] CHECK CONSTRAINT [FK_cR_asignacion]
GO
ALTER TABLE [dbo].[Crystal]  WITH CHECK ADD  CONSTRAINT [FK_cR_ficha] FOREIGN KEY([id_ficha])
REFERENCES [dbo].[ficha] ([id_ficha])
GO
ALTER TABLE [dbo].[Crystal] CHECK CONSTRAINT [FK_cR_ficha]
GO
ALTER TABLE [dbo].[Crystal]  WITH CHECK ADD  CONSTRAINT [FK_cR_resultado] FOREIGN KEY([id_resultado])
REFERENCES [dbo].[resultado] ([id_resu])
GO
ALTER TABLE [dbo].[Crystal] CHECK CONSTRAINT [FK_cR_resultado]
GO
ALTER TABLE [dbo].[Crystal]  WITH CHECK ADD  CONSTRAINT [FK_cR_tbl_instructor] FOREIGN KEY([id_instructor])
REFERENCES [dbo].[tbl_instructor] ([id_instructor])
GO
ALTER TABLE [dbo].[Crystal] CHECK CONSTRAINT [FK_cR_tbl_instructor]
GO
ALTER TABLE [dbo].[ficha_cohorte]  WITH CHECK ADD  CONSTRAINT [FK_ficha_cohorte_cohorte] FOREIGN KEY([id_cohorte])
REFERENCES [dbo].[cohorte] ([id_coho])
GO
ALTER TABLE [dbo].[ficha_cohorte] CHECK CONSTRAINT [FK_ficha_cohorte_cohorte]
GO
ALTER TABLE [dbo].[ficha_cohorte]  WITH CHECK ADD  CONSTRAINT [FK_ficha_cohorte_ficha] FOREIGN KEY([id_ficha])
REFERENCES [dbo].[ficha] ([id_ficha])
GO
ALTER TABLE [dbo].[ficha_cohorte] CHECK CONSTRAINT [FK_ficha_cohorte_ficha]
GO
ALTER TABLE [dbo].[ficha_programa]  WITH CHECK ADD  CONSTRAINT [FK_ficha_programa_] FOREIGN KEY([id_programa])
REFERENCES [dbo].[programa] ([id_prog])
GO
ALTER TABLE [dbo].[ficha_programa] CHECK CONSTRAINT [FK_ficha_programa_]
GO
ALTER TABLE [dbo].[ficha_programa]  WITH CHECK ADD  CONSTRAINT [FK_ficha_programa_ficha] FOREIGN KEY([id_ficha])
REFERENCES [dbo].[ficha] ([id_ficha])
GO
ALTER TABLE [dbo].[ficha_programa] CHECK CONSTRAINT [FK_ficha_programa_ficha]
GO
ALTER TABLE [dbo].[instructor_asignacion]  WITH CHECK ADD  CONSTRAINT [FK_instructor_asignacion_asignacion] FOREIGN KEY([id_asignacion])
REFERENCES [dbo].[asignacion] ([id_asig])
GO
ALTER TABLE [dbo].[instructor_asignacion] CHECK CONSTRAINT [FK_instructor_asignacion_asignacion]
GO
ALTER TABLE [dbo].[instructor_asignacion]  WITH CHECK ADD  CONSTRAINT [FK_instructor_asignacion_tbl_instructor] FOREIGN KEY([id_instructor])
REFERENCES [dbo].[tbl_instructor] ([id_instructor])
GO
ALTER TABLE [dbo].[instructor_asignacion] CHECK CONSTRAINT [FK_instructor_asignacion_tbl_instructor]
GO
ALTER TABLE [dbo].[instructor_programa]  WITH CHECK ADD  CONSTRAINT [FK_instructor-programa_programa] FOREIGN KEY([id_prog])
REFERENCES [dbo].[programa] ([id_prog])
GO
ALTER TABLE [dbo].[instructor_programa] CHECK CONSTRAINT [FK_instructor-programa_programa]
GO
ALTER TABLE [dbo].[instructor_programa]  WITH CHECK ADD  CONSTRAINT [FK_instructor-programa_tbl_instructor] FOREIGN KEY([id_intructor])
REFERENCES [dbo].[tbl_instructor] ([id_instructor])
GO
ALTER TABLE [dbo].[instructor_programa] CHECK CONSTRAINT [FK_instructor-programa_tbl_instructor]
GO
ALTER TABLE [dbo].[lineaTecno_programa]  WITH CHECK ADD  CONSTRAINT [FK_lineaTecno_programa_linea_tecno] FOREIGN KEY([id_linea_tecno])
REFERENCES [dbo].[linea_tecno] ([id_linea_tecno])
GO
ALTER TABLE [dbo].[lineaTecno_programa] CHECK CONSTRAINT [FK_lineaTecno_programa_linea_tecno]
GO
ALTER TABLE [dbo].[lineaTecno_programa]  WITH CHECK ADD  CONSTRAINT [FK_lineaTecno_programa_programa] FOREIGN KEY([id_prog])
REFERENCES [dbo].[programa] ([id_prog])
GO
ALTER TABLE [dbo].[lineaTecno_programa] CHECK CONSTRAINT [FK_lineaTecno_programa_programa]
GO
ALTER TABLE [dbo].[programa_ambiente]  WITH CHECK ADD  CONSTRAINT [FK_programa_ambiente_ambiente] FOREIGN KEY([id_prog])
REFERENCES [dbo].[ambiente] ([id_amb])
GO
ALTER TABLE [dbo].[programa_ambiente] CHECK CONSTRAINT [FK_programa_ambiente_ambiente]
GO
ALTER TABLE [dbo].[programa_ambiente]  WITH CHECK ADD  CONSTRAINT [FK_programa_ambiente_programa] FOREIGN KEY([id_prog])
REFERENCES [dbo].[programa] ([id_prog])
GO
ALTER TABLE [dbo].[programa_ambiente] CHECK CONSTRAINT [FK_programa_ambiente_programa]
GO
ALTER TABLE [dbo].[tema_resultado]  WITH CHECK ADD  CONSTRAINT [FK_tema_resultado_resultado] FOREIGN KEY([id_resultado])
REFERENCES [dbo].[resultado] ([id_resu])
GO
ALTER TABLE [dbo].[tema_resultado] CHECK CONSTRAINT [FK_tema_resultado_resultado]
GO
ALTER TABLE [dbo].[tema_resultado]  WITH CHECK ADD  CONSTRAINT [FK_tema_resultado_tbl_tema] FOREIGN KEY([id_tema])
REFERENCES [dbo].[tbl_tema] ([id_tema])
GO
ALTER TABLE [dbo].[tema_resultado] CHECK CONSTRAINT [FK_tema_resultado_tbl_tema]
GO
USE [master]
GO
ALTER DATABASE [Bdd_Ctgi] SET  READ_WRITE 
GO
