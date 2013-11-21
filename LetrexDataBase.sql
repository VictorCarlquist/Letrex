use master
go

create database LOPAII
go

use LOPAII
go

create table verbetes (
	cod_verbete int primary key identity(1,1),
	verbete nvarchar(255) not null
)
go

create table jogadores (
	cod_jogador int primary key identity(1,1),
	nome_jogador nvarchar(255) not null,
	pontuacao_jogador int default 0 not null,
	level_jogador tinyint default 0 not null
)
go

insert into jogadores(nome_jogador) values 
	('Guilherme'),
	('Pedro'),
	('Jonas')
go


BULK INSERT tmp_verbetes FROM 'f:\pt_BR.dic.dic'
WITH
(
      CODEPAGE = 'ACP'
);

select * from verbetes
go

begin transaction 
	delete from verbetes where LEN(verbete) > 9;
commit
go

select COUNT(*) from verbetes
go
