create database Mantenimiento_Productos;

use Mantenimiento_Productos

create table categoria(
idCategoria INT IDENTITY(1,1)PRIMARY KEY NOT NULL,
codigo AS ('CT'+ RIGHT	('00' + convert(VARCHAR,idCategoria),(2))),
nombre NVARCHAR(30) NOT NULL,
descripcion NVARCHAR(256) NULL
)

INSERT INTO categoria VALUES ('HERRAMIENTAS','LAS MEJORES HERRAMIENTAS')
INSERT INTO categoria VALUES ('PINTURAS','LAS MEJORES PINTURAS PARA TU CASA')

SELECT * FROM categoria


