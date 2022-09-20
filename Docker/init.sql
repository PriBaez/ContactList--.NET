IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'CRUDCORE')
BEGIN
    CREATE DATABASE CRUDCORE;
END;
GO

USE CRUDCORE;
GO

CREATE TABLE CONTACTOS(  
    Con_ID INT IDENTITY primary key, 
    Con_Nombre varchar(50) NOT NULL,  
    Con_Telefono varchar(50),  
    Con_Correo varchar(50)
);
GO

CREATE PROCEDURE sp_listar AS BEGIN seLect * from CONTACTOS END
GO

CREATE PROCEDURE sp_obtener(@IdContacto int) 
AS BEGIN 
select * from CONTACTOS where Con_ID = @IdContacto END
GO

CREATE PROCEDURE sp_guardar(@Nombre varchar(50), @Telefono varchar(50), @Correo varchar(50)) 
AS BEGIN 
INSERT INTO CONTACTOS (Con_Nombre, Con_Telefono, Con_Correo) VALUES (@Nombre, @Telefono, @Correo) END
GO


CREATE PROCEDURE sp_editar( @IdContacto int, @Nombre varchar(50), @Telefono varchar(50), @Correo varchar(50)) 
AS BEGIN 
UPDATE CONTACTOS SET Con_Nombre = @Nombre, Con_Telefono = @Telefono, Con_Correo = @Correo WHERE Con_ID = @IdContacto END	
GO

CREATE PROCEDURE sp_eliminar(@IdContacto int) 
AS BEGIN 
DELETE FROM CONTACTOS WHERE Con_ID = @IdContacto END
GO



