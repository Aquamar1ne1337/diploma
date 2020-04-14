﻿create table Тип
(
	id_типа int not null identity(1,1),
	Название varchar(20) not null
	constraint cs_pktype primary key(id_типа)
)
go

insert Тип
	values ('Администратор'),
			('Клиент')
go

select * from Тип
go

create table Пользователь
(
	id_пользователя int not null identity(1,1),
	id_типа int not null default 2,
	Логин varchar(30) not null unique,
	Пароль varchar(30) not null
	constraint cs_pkuser primary key(id_пользователя),
	constraint cs_fktype foreign key(id_типа) references Тип(id_типа) on update cascade on delete cascade
)
go

CREATE TABLE Задание(
	id_задания int IDENTITY(1,1) NOT NULL,
	id_клиента int NOT NULL,
	Название varchar(100) NOT NULL,
	Описание varchar(max) NOT NULL,
	Дата_создания datetime NOT NULL,
	Крайний_срок datetime NOT NULL,
	constraint cs_pktask primary key(id_задания),
	constraint cs_fkclient foreign key(id_клиента) references Клиент(id_клиента) on update cascade on delete cascade
	)
	go

	CREATE TABLE Заметка(
	id_заметки int IDENTITY(1,1) NOT NULL,
	id_распределения int NOT NULL,
	Содержание varchar(max) NULL,
	Дата_добавления datetime NOT NULL,
	constraint cs_pknote primary key(id_заметки),
	constraint cs_fkdistribution foreign key(id_распределения) references Распределение(id_распределения) on update cascade on delete cascade
	)
	go

	CREATE TABLE Клиент(
	id_клиента int IDENTITY(1,1) NOT NULL,
	Имя varchar(50) NOT NULL,
	Электронная_почта varchar(max) NOT NULL,
	Дата_регистрации date NOT NULL,
	Телефон varchar(20) NOT NULL,
	Город varchar(50) NOT NULL,
	constraint cs_pkclient primary key(id_клиента)
	)
	go

	CREATE TABLE Распределение(
	id_распределения int IDENTITY(1,1) NOT NULL,
	id_пользователя int NOT NULL,
	id_задания int NOT NULL,
	Дата_распределения datetime NOT NULL,
	constraint cs_pkdistribution primary key(id_распределения),
	constraint cs_fktasksecond foreign key(id_задания) references Задание(id_задания) on update cascade on delete cascade,
	constraint cs_fkuser foreign key(id_пользователя) references Пользователь(id_пользователя) on update cascade on delete cascade
	)
	go
	
CREATE TABLE Статус(
	id_статуса int IDENTITY(1,1) NOT NULL,
	id_задания int NOT NULL,
	Состояние varchar(100) NOT NULL,
	constraint cs_pkstatus primary key(id_статуса),
	constraint cs_fktask foreign key(id_задания) references Задание(id_задания) on update cascade on delete cascade
	)
	go



create procedure SignUp
@login varchar(20),
@password varchar(max) as 
begin
insert into Пользователь(Логин, Пароль) values (@login, @password)
end
GO


CREATE procedure ClientUpdate
@name varchar(50),
@email varchar(100),
@date date,
@phone varchar(20),
@town varchar(50),
@id int as 
begin
	update Клиент 
	set Имя = @name, Электронная_почта = @email, Дата_регистрации = @date, Телефон = @phone, Город = @town
	where id_клиента = @id
end
GO

CREATE procedure ClientAdd
@name varchar(50),
@email varchar(100),
@date date,
@phone varchar(20),
@town varchar(50) as
begin
	insert into Клиент(Имя, Электронная_почта, Дата_регистрации, Телефон, Город) values (@name, @email, @date, @phone, @town)
end
GO