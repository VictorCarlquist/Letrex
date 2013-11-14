use master
go

create database LOPAII
go

use LOPAII
go

create table tmp_verbetes (
	verbete nvarchar(255) not null
)
go

create table verbetes (
	cod_verbete int primary key identity(1,1),
	verbete nvarchar(255) not null
)
go

drop table usuarios
go

create table usuarios (
	cod_usuario int primary key identity(1,1),
	nome_usuario nvarchar(255) not null,
	pontuacao_usuario int default 0 not null,
	level_usuario tinyint default 0 not null
)
go

insert into usuarios(nome_usuario) values 
	('Guilherme'),
	('Pedro'),
	('Jonas')
go


BULK INSERT tmp_verbetes FROM 'C:\pt_BR.dic'
WITH
(
      CODEPAGE = 'ACP'
);

select * from verbetes
go

insert into verbetes (verbete) (select verbete from tmp_verbetes)
go
